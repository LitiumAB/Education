# Redis

> To do this task you first need to complete the task [Docker](../Docker)

## Connect Litium to Redis

Make the changes below in the Redis-section in `appsettings.json`:

1. A Redis container was started in the [Docker task](../Docker), add connectionstrings to it for the Redis-features you want to enable.

1. By setting a value for Prefix you can use the same Redis-container for multiple local Litium installations, just use a unique prefix for every installation.

```JSON
"Redis": {
   "Prefix": "LitiumEducation",
   "Cache": {
      "ConnectionString": "localhost:6379",
      "Password": null
   },
   "DistributedLock": {
      "ConnectionString": "localhost:6379",
      "Password": null
   },
   "ServiceBus": {
      "ConnectionString": "localhost:6379",
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

Additional Cache configuration options can be found on [Litium Docs](https://docs.litium.com/documentation/get-started/configuration).

## Verify

After startup you can use a tool such as for example [Another Redis Desktop Manager](https://github.com/qishibo/AnotherRedisDesktopManager) to connect to Redis and view, delete or edit the data stored in Redis.

Note that the data is stored encrypted and not human readable.

## Optional extra tasks

> To do the additional tasks you first need to complete the task [Pricing rules](../Pricing%20rules)

A finished example implementing both distributed cache and distributed lock is avaliable in the [_Resources_-folder](Resources/ErpPriceCalculatorDecorator.cs)

### 1. Distributed cache

To get better performance when getting price from external sources such as ERP you always need to add data to cache. By using a distributed cache in Redis the same cache is used for all your web applications.

You will be using the `DistributedMemoryCache` which stores data both in a short (2 minute) memory cache in the application and also in a distributed cache (Redis) for 24 hours.

1. Make your price fetch really slow by adding `Thread.Sleep(500);` before returning price for a variant and then test the performance on a category page listing multiple products
1. Inject `DistributedMemoryCacheService` in the constructor of `ErpPriceCalculatorDecorator`
1. First try getting the value from cache before your `Thread.Sleep`:

   ```C#
   var cacheKey = $"{nameof(ErpPriceCalculatorDecorator)}:{variantSystemId}";
   if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out var price))
      return price;
   ```

1. Then make sure you store the price in cache after getting it from ERP:

   ```C#
   _distributedMemoryCacheService.Set(cacheKey, price);
   ```

1. Test by reloading your product listing again, now only the first page load should be slow and all consecutive page loads should be instant

> Note that expiration is sliding so in any production sceario you would also need to add functionality to clear cached price on any price change event.

### 2. Distributed lock

When multiple threads or applications might access the same data at the same time it is important to lock the resource to avoid conflicts.

The price calculator has to prevent multiple requests to ERP for the same variant. You do this by placing a lock on the variant while you fetch the price to prevent other servers or threads from calling the API for the same data.

1. Inject `DistributedLockService` in the constructor of `ErpPriceCalculatorDecorator`
1. Wrap the code where you get price for a variant in a lock:

   ```C#
   using (_distributedLockService.AcquireLock(cacheKey, TimeSpan.FromSeconds(10)))
   {
      // Try getting value from cache again since it may have been added
      // from another thread/app while you were waiting for the lock
      if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out price))
         return price;

       // Rest of implementation code for getting variant price
       ...
   }
   ```
