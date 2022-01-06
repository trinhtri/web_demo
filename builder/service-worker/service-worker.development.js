import { CacheableResponsePlugin } from 'workbox-cacheable-response/CacheableResponsePlugin';
import { CacheFirst } from 'workbox-strategies/CacheFirst';
import { ExpirationPlugin } from 'workbox-expiration/ExpirationPlugin';
import { registerRoute } from 'workbox-routing/registerRoute';

import './service-worker.base';