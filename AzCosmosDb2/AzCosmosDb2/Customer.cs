using Newtonsoft.Json;

public class Customer
{
    [JsonProperty("id")]
    public string customerId { get; set; }

    public string customerName { get; set; }

    public string customerCity { get; set; }

    public List<Order> orders { get; set; }
}