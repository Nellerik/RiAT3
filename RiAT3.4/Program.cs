using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;

public class Program
{
    public static async Task Main()
    {
        var options = new RestClientOptions("https://api.foursquare.com/v3/places/search?ll=55.48628796307604%2C28.76350062509225&radius=400&categories=13065");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "fsq3Yo1BK3BCLRpSMi8kgPd7HM1fjFIXq4BDELWbWA4XQL0=");
        var response = await client.GetAsync(request);

        Console.WriteLine("{0}", response.Content);
    }
}