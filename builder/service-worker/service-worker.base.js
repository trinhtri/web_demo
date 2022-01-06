import { setCacheNameDetails, clientsClaim, setConfig } from 'workbox-core';
import { CacheableResponsePlugin } from 'workbox-cacheable-response/CacheableResponsePlugin';
import { StaleWhileRevalidate } from 'workbox-strategies/StaleWhileRevalidate';
import { ExpirationPlugin } from 'workbox-expiration/ExpirationPlugin';
import { precacheAndRoute } from 'workbox-precaching/precacheAndRoute';
import { registerRoute } from 'workbox-routing/registerRoute';

clientsClaim();
self.skipWaiting();
self.__WB_DISABLE_DEV_LOGS = true;
setCacheNameDetails({ precache: 'SuparCar' });

const ignored = self.__WB_MANIFEST;

precacheAndRoute([]);