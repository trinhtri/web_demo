
import { ModuleLoader } from './module-loader';
export class FrontEndApp {
  #moduleLoader = new ModuleLoader();
  #options = {
    autoInit: true,
    serviceWorker: true,
  };

  constructor(options = {}) {
    this.#options = {
      ...this.#options,
      ...options,
    };

    if (this.#options.autoInit) {
      this.init().catch((ex) => {
        console.log(ex);
      });
    }
  }

  #initSW = () => {
    if ('serviceWorker' in navigator) {
      window.addEventListener('load', () => {
        navigator.serviceWorker
          .register('/sw.js')
          .then((registration) => {
            console.log('SW registered: ', registration);
          })
          .catch((registrationError) => {
            console.log('SW registration failed: ', registrationError);
          });
      });
    }
  }


  #loadAppModules = () => {
    if (typeof this.moduleResolver === 'function') {
      return this.#moduleLoader.load({
        context: this.moduleResolver(), source: 'app'
      });
    }
    return [];
  }

  #loadCoreModules = () => {
    return this.#moduleLoader.load({
      context: require.context('../modules', true, /\/index.js$/),
      source: 'app',
    });
  }

  #loadModule = async () => {
    const { ModuleInjection } = await import('./module-injection');
    const moduleInjection = new ModuleInjection();
    moduleInjection.inject([...this.#loadAppModules(), ...this.#loadCoreModules()]);
  };

  init = async () => {
    await this.#loadModule();
    if (this.#options.serviceWorker) {
      this.#initSW();
    }
  }
}