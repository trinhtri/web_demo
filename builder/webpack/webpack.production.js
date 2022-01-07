const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const { InjectManifest } = require('workbox-webpack-plugin');

const helpers = require('./helpers');
const { entry, projectFolder } = helpers.getProjectInfo();

module.exports = require('./webpack.base')({
  mode: 'production',

  entry: {
    ...entry,
  },

  // Utilize long-term caching by adding content hashes (not compilation hashes) to compiled assets
  output: {
    filename: '[name].[chunkhash].js',
    publicPath: 'dist/',
    chunkFilename: '[name].[chunkhash].chunk.js',
  },

  optimization: {
    minimize: true,
    nodeEnv: 'production',
    runtimeChunk: true,
  },

  plugins: [
    new InjectManifest({
      swSrc: `./builder/service-worker/service-worker.${process.env.NODE_ENV}.js`,
      swDest: `../sw.js`,
      // swDest: `../../Views/Shared/Layouts/sw.js`,
      include: [],
    }),
    new MiniCssExtractPlugin({
      filename: '[name].[chunkhash].css',
      chunkFilename: '[name].[chunkhash].chunk.css',
    }),
  ],
});
