import { CacheableResponsePlugin } from 'workbox-cacheable-response/CacheableResponsePlugin';
import { CacheFirst } from 'workbox-strategies/CacheFirst';
import { ExpirationPlugin } from 'workbox-expiration/ExpirationPlugin';
import { registerRoute } from 'workbox-routing/registerRoute';

import './service-worker.base';

// Cache web
// registerRoute(
//   new RegExp('^https://test.com/dist'),
//   new CacheFirst({
//     cacheName: 'web-cache',
//     plugins: [
//       new CacheableResponsePlugin({
//         statuses: [0, 200],
//       }),
//       new ExpirationPlugin({
//         maxAgeSeconds: 60 * 60 * 24 * 3, //3 days
//       }),
//     ],
//   })
// );
