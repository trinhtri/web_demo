const HtmlWebpackPlugin = require('html-webpack-plugin');
const HtmlWebpackHarddiskPlugin = require('html-webpack-harddisk-plugin');
const HTMLInlineCSSWebpackPlugin = require("html-inline-css-webpack-plugin").default;


const isDev = process.env.NODE_ENV === 'development';

const fs = require('fs');
const path = require('path');
const forEach = require('lodash/forEach');
const groupBy = require('lodash/groupBy');
const pick = require('lodash/pick');
const snakeCase = require('lodash/snakeCase');
const isNil = require('lodash/isNil');
const merge = require('lodash/merge');
const glob = require('glob');
const uniqueId = require('lodash/uniqueId');
const slugify = require('slugify');

function generateTemplate(content, { files }) {
  const { js, css } = files;
  return content
    .replace(
      /(([ \t]*)<!--\s*builder:css\s*-->)(\n|\r|.)*?(<!--\s*endbuilder:css\s*-->)/gi,
      `<!-- builder:css -->
      ${css.map((link) => `<link href="${link}" rel="stylesheet">`).join('\n')}
      <!-- endbuilder:css -->`,
    )
    .replace(
      /(([ \t]*)<!--\s*builder:js\s*-->)(\n|\r|.)*?(<!--\s*endbuilder:js\s*-->)/gi,
      `<!-- builder:js -->
      ${js.map((link) => `<script defer src="${link}"></script>`).join('\n')}
      <!-- endbuilder:js -->`,
    );
}

function objectToEnv(object) {
  const env = {};

  forEach(object, (value, key) => {
    const envKey = snakeCase(key).toUpperCase();
    env[`${envKey}`] = JSON.stringify(value);
  });
  return env;
}

function getHTMLPlugins(chunks) {
  const plugins = [];
  const chunkByViews = groupBy(chunks, 'view');
  forEach(chunkByViews, (items, view) => {
    plugins.push(
      new HtmlWebpackPlugin({
        minify: false,
        inject: false,
        filename: view,
        alwaysWriteToDisk: true,
        templateContent: ({ htmlWebpackPlugin }) => {
          return generateTemplate(fs.readFileSync(view).toString(), htmlWebpackPlugin)
        },
        chunks: [
          ...items.map(({ chunk }) => chunk),
          ...(isDev ? ['hot-reload'] : []),
        ],
      }),
    );
  });

  plugins.push(new HtmlWebpackHarddiskPlugin());
  return plugins;
}

function getProjects() {
  const configPath = path.resolve(process.cwd(), `*/builder.config.json`);
  const files = glob.sync(configPath);
  return files.map((filePath) => {
    const { name } = path.parse(filePath);
    return name;
  });
}

function getProjectInfo(folder = process.env.PROJECT || 'DGod.SuparCar.Host') {
  const projectFolderPath = path.resolve(process.cwd(), `${folder}`);
  const configPath = `${projectFolderPath}/builder.config.json`;
  const appSettings = mergeAppConfig(projectFolderPath, process.env.ASPNETCORE_ENVIRONMENT)

  //Load project config
  const rawConfig = require(configPath); //eslint-disable-line
  // const rawAppSetting = require(appSettingPath); //eslint-disable-line
  const rawAppSetting = appSettings; //eslint-disable-line

  const { assetsFolder, outputFolder, entryPoints=[], modules = [], appSettingKeys = [] } = rawConfig;

  const assetsFolderPath = path.resolve(projectFolderPath, assetsFolder);
  const entry = {
    // common: path.resolve(folder,assetsFolder,'index.js')
  };
  
  const moduleConfigs = []  
  //Read all layouts
  let defaultViews = [];
  const paths = {}
  paths[`${Object.keys({outputFolder})[0]}Path`] = path.resolve(projectFolderPath, outputFolder);

  forEach(modules, (module) => {
    let folder = path.resolve(process.cwd(), `${module}`);
    let configP = `${folder}/builder.config.json`;
    let config = require(configP); 
    const { assetsFolder: af } = config;
    paths[module] = path.resolve(folder, af);
    const chunkName = slugify(`common-${config.name}`).toLowerCase();
    forEach(config.entryPoints, (ep)=>{
      entryPoints.push({...ep, module: module, folder: folder, chunkName: slugify(config.name).toLowerCase()});
    })

    entry[chunkName] = path.resolve(folder, af,'index.js');
    moduleConfigs.push(config);

    defaultViews = [...defaultViews, {
      chunk: chunkName,
      viewPaths: [
      ...glob.sync(path.resolve(folder, `./Views/Shared/Layouts/*.cshtml`)),
      ...glob.sync(path.resolve(folder, `./Views/Shared/Layouts/*.html`))]
    }]
  })

  // defaultViews = [...defaultViews, {chunk:"common", viewPaths: [
  //   ...glob.sync(path.resolve(folder, `./Views/Shared/Layouts/*.cshtml`)),
  //   ...glob.sync(path.resolve(folder, `./Views/Shared/Layouts/*.html`))]
  // }]

  let chunks = []

  forEach(defaultViews, ((view) => {
    const { chunk, viewPaths } = view;
    chunks = [...chunks,...viewPaths.map((viewPath) => {
      return {
        chunk: chunk,
        view: path.resolve(viewPath)
      };
    })]
  }))
  // default webpack entry
  
  //Build entry points based pages
  forEach(entryPoints, ({ name, file, views, module, folder, chunkName }) => {

    const alias = slugify(`${name}-${chunkName}`).toLowerCase();
    const filePath = path.resolve(paths[module], file);

    // automatically inject script & css
    forEach(views, (viewPath) => {
      chunks.push({
        chunk: alias,
        view: path.resolve(folder, viewPath),
      });
    });

    // webpack entry
    entry[alias] = filePath;
  });

  const envConfig = rawConfig.env || {};
  
  return {
    ...rawConfig,
    projectFolder: folder,
    projectFolderPath,
    assetsFolderPath,
    entry,
    chunks,
    ...paths,
    ...(envConfig[process.env.NODE_ENV] || {}),
    appSettings: pick(rawAppSetting.AppSettings || {}, appSettingKeys),
  };
}

function mergeAppConfig(projectFolderPath, env) {
  var cfg = {};
  mergeConfig(cfg, `${projectFolderPath}/appsettings.base.json`);
  mergeConfig(cfg, `${projectFolderPath}/appsettings.${env}.json`);
  fs.writeFile(`${projectFolderPath}/appsettings.json`, JSON.stringify(cfg), function (err) {
    if (err) return console.log('Merge appsettings.json ', err);
    console.log(`Merge appsettings.json cho Enviroment ${env}`);
  });
  return cfg;
}

function mergeConfig(cfg, envFile) {
  if (isNil(cfg)) cfg = {};
  if (fs.existsSync(envFile)) {
    cfg = merge(cfg, require(envFile));
  }
  return cfg;
}

module.exports = {
  getProjectInfo,
  getProjects,
  getHTMLPlugins,
  objectToEnv,
};
