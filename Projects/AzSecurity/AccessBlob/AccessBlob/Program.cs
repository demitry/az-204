using Newtonsoft.Json;
using System.Net.Http.Headers;

string tokenUri = "http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://storage.azure.com";
HttpClient httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Metadata", "true");

// Get the access token:

HttpResponseMessage response = await httpClient.GetAsync(tokenUri);
string content = await response.Content.ReadAsStringAsync();

Console.WriteLine("Response Content: " + content);

Dictionary<string,string> values = JsonConvert.DeserializeObject<Dictionary<string,string>>(content);

if(values == null)
{
    Console.WriteLine("Cannot parse response, Quit");
    return;
}

foreach(KeyValuePair<string,string> pair in values)
{
    Console.WriteLine("Key is " + pair.Key);
    Console.WriteLine("Value is " + pair.Value);
}

Console.WriteLine("values[\"access_token\"] is" + values["access_token"]);

// We can now access the blob using access token

string applicationUri = "https://stacc505050.blob.core.windows.net/mycontainer/myfile.txt";

HttpClient httpClientStorage = new HttpClient();
httpClientStorage.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", values["access_token"]);
httpClientStorage.DefaultRequestHeaders.Add("x-ms-version", "2017-11-09");

HttpResponseMessage blobResponse = await httpClientStorage.GetAsync(applicationUri);
string blobContent = await blobResponse.Content.ReadAsStringAsync();

Console.WriteLine("blob content: " + blobContent);
Console.Read();