# Redis

> To do this task you first need to complete the task [Docker](../Docker)

## Connect Litium to Redis

To enable Redis features you need to set a connectionstring so that your Litium Application can connect from its container to the Redis container that was created in the [Docker task](../Docker).

By also setting a value for Prefix we can use the same Redis-container for multiple local Litium installations, just use a unique prefix for every installation.

Make the following changes in `appsettings.json` in the MVC-project:

   ```JSON
   "Redis": {
      "Prefix": "LitiumEducation",
      "Cache": {
         "ConnectionString": "host.docker.internal:6379",
         "Password": null
      },
      "DistributedLock": {
         "ConnectionString": "host.docker.internal:6379",
         "Password": null
      },
      "ServiceBus": {
         "ConnectionString": "host.docker.internal:6379",
         "Password": null
      }
   }
   ```

Optionally you can also for local testing adjust cache-settings to limit the time items are stored in Redis (do not deploy these settings to production):

```JSON
"Cache": {
   "Distributed": {
      "DefaultMemorySlidingExpiration": 120,
      "DefaultDistributedSlidingExpiration": 600
   }
}
```

## Verify

After startup you can use a tool such as for example [Another Redis Desktop Manager](https://github.com/qishibo/AnotherRedisDesktopManager) to connect to Redis and view, delete or edit the data stored in Redis.

Note that the data is stored encrypted and not human readable.

## Optional extra tasks

> To do the additional tasks you first need to complete the task [Pricing rules](../Pricing%20rules)

A finished example implementing both distributed cache and distributed lock is avaliable in the [_Resources_-folder](Resources/ERPPriceCalculatorImpl.cs)

### 1. Distributed cache

To get better performance when getting price from external sources such as ERP we always need to add data to cache. By using a distributed cache in Redis the same cache is used for all our web applications.

We will be using the `DistributedMemoryCache` which stores data both in a short (2 minute) memory cache in the application and also in a distributed cache (Redis) for 24 hours.

1. Make your price fetch really slow by adding `Thread.Sleep(500);` before returning price for a variant and then test the performance on a category page listing multiple products
1. Inject `DistributedMemoryCacheService` in the constructor of `ErpPriceCalculatorDecorator`
1. First try getting the value from cache before your `Thread.Sleep`:

   ```C#
   var cacheKey = $"{nameof(ERPPriceCalculatorImpl)}:{variantSystemId}";
   if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out var price))
      return price;
   ```

1. Then make sure you store the price in cache after getting it from ERP:

   ```C#
   _distributedMemoryCacheService.Set(cacheKey, price);
   ```

1. Test by reloading your product listing again, now only the first page load should be slow and all consecutive page loads should be instant

> Note that expiration is sliding so in any production sceario we would also need to add functionality to clear cached price on any price change event.

### 2. Distributed lock

When multiple threads or applications might access the same data at the same time it is important to lock the resource to avoid conflicts.

In our price calculator we need to prevent multiple requests to ERP for the same variant. We do this by locking the variant while we fetch the price to prevent other servers or threads from calling the API for the same data.

1. Inject `DistributedLockService` in the constructor of `ErpPriceCalculatorDecorator`
1. Wrap the code where we get price for a variant in a lock:

   ```C#
   using (_distributedLockService.AcquireLock(cacheKey, TimeSpan.FromSeconds(10)))
   {
      // Try getting value from cache again since it may have been added
      // from another thread/app while we were waiting for the lock
      if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out price))
         return price;

       // Rest of implementation code for getting variant price
       ...
   }
   ```
