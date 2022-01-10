import loadable from '@loadable/component'

const Widget = loadable(() => import('./Widget'));

export default {
  lazyLoad: true,
  component: Widget,
  placeholder: null,
};