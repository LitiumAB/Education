# Redis

> To do this task you first need to complete the task [Docker](../Docker) 

Redis is only avaliable in Litium version 7.3 and later.

### Connect Litium to Redis

1. Install the nuget package for Redis in the MVC-project of your Litium solution (details can be found [here](https://docs.litium.com/documentation/get-started/multi-server-installation/redis))
   ```console
   Install-Package Litium.Web.Setup.Redis 
   ```
1. The package adds new values to the `connectionStrings`-section in *Web.config*:
   ```XML
   <add name="RedisCacheConnectionString" connectionString="Replace with Redis Connection string" />
   <add name="RedisServiceBusConnectionString" connectionString="Replace with Redis Connection string" />
   <add name="RedisDistributedLockConnectionString" connectionString="Replace with Redis Connection string" />
   ```
   Set your redis connectionstring as the three connectionstrings, your connectionstring is localhost with the port-number defined when the container was added in the [Docker task](../Docker):
   ```XML
   <add name="RedisCacheConnectionString" connectionString="127.0.0.1:6379" />
   <add name="RedisServiceBusConnectionString" connectionString="127.0.0.1:6379" />
   <add name="RedisDistributedLockConnectionString" connectionString="127.0.0.1:6379" />
   ```
1. By adding a prefix it is possible for multiple Litium sites to share a single Redis application. Add the following key to the `appSettings`-section in *Web.config*:
   ```XML
   <add key="Litium:Redis:Prefix" value="Bookstore:" />
   ```

### Verify

1. After startup you can use a tool such as for example [Another Redis Desktop Manager](https://github.com/qishibo/AnotherRedisDesktopManager) to connect to Redis and view, delete or edit the data stored in Redis.

### Cleanup

1. If you want to stop and remove your Redis-container, you can find instructions [here](https://linuxize.com/post/how-to-remove-docker-images-containers-volumes-and-networks/)

## Optional extra tasks 

> To do the additional tasks you first need to complete the task [Pricing rules](../Pricing%20rules)

### 1. Distributed cache

To get better performance when getting price from external sources such as ERP we always need to add data to cache. By using a distributed cache in Redis the same cache is used for all our web applications.

We will be using the `DistributedMemoryCache` which stores data both in a short (2 minute) memory cache in the application and also in a distributed cache (Redis) for 24 hours.

1. Make your price fetch really slow by adding `Thread.Sleep(800);` before returning price for a variant and then test the performance on a category page listing multiple products
1. Inject `DistributedMemoryCacheService` in the constructor of `ERPPriceCalculatorImpl`
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

1. Inject `DistributedLockService` in the constructor of `ERPPriceCalculatorImpl`
1. Wrap the code where we get price for a variant in a lock:
   ```C#
   using (_distributedLockService.AcquireLock(cacheKey, TimeSpan.FromSeconds(10)))
   {
      // Try getting value from cache again since it was likely added while we were waiting for the lock
      if (_distributedMemoryCacheService.TryGet<PriceCalculatorResult>(cacheKey, out price))
         return price;

       // Rest of implementation code for getting variant price
       ...
   }
   ```
