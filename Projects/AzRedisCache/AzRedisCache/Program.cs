using StackExchange.Redis;

string connectionString = "appcache1000.redis.cache.windows.net:6380,password=4o5...60c=,ssl=True,abortConnect=False";

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

SetCacheData();

GetCacheData();