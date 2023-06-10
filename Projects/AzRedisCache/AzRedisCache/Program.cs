using AzRedisCache;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

//string connectionString = "appcache1000.redis.cache.windows.net:6380,password=4o5...60c=,ssl=True,abortConnect=False";
string connectionString = "appcache1000.redis.cache.windows.net:6380,password=4o5FaUASBDttACpArQSE7Dp29dAn655RxAzCaAES60c=,ssl=True,abortConnect=False";

string keyTopCourses = "top:3:courses";

ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);

void SetCacheData()
{
    IDatabase database = redis.GetDatabase();
    database.StringSet(keyTopCourses, "AZ-104,AZ-305,AZ-204");
    Console.WriteLine("Cache data has been set");
}

void GetCacheData()
{
    IDatabase database = redis.GetDatabase();

    string? result = database.KeyExists(keyTopCourses) ? 
        database.StringGet(keyTopCourses) : "Key does not exist";
    
    Console.WriteLine(result);
}

void SetClassCacheData(string userId, int productId, int quantity)
{
    IDatabase database = redis.GetDatabase();
    CartItem cartItem = new CartItem() { ProductId = productId, Quantity = quantity };
    string key = String.Concat(userId, ":cartitems");
    database.ListRightPush(key, JsonConvert.SerializeObject(cartItem));
    Console.WriteLine("Cache data has been set");
}

List<CartItem> GetClassCacheData(string userId)
{
    IDatabase database = redis.GetDatabase();
    string key = String.Concat(userId, ":cartitems");
    RedisValue[] redisValues = database.ListRange(key);
    List<CartItem> cartItems = new List<CartItem>();

    foreach (var redisValue in redisValues)
    {
        CartItem cartItem = JsonConvert.DeserializeObject<CartItem>(redisValue);
        cartItems.Add(cartItem);
    }

    foreach (var cart in cartItems)
    {
        Console.WriteLine($"{cart.ProductId} {cart.Quantity}");
    }

    return cartItems;
}


//SetClassCacheData("u1", 10, 100);
//SetClassCacheData("u1", 20, 500);
//SetClassCacheData("u1", 30, 200);

var list = GetClassCacheData("u1");

//lrange u1:cartitems 0 -1

//SetCacheData();

//GetCacheData();