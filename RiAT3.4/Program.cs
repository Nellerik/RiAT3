using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

public class Program
{
    public static async Task Main()
    {
        var options = new RestClientOptions("https://api.weather.yandex.ru/v2/forecast/?lat=55.48628796307604&lon=28.76350062509225&lang=ru_RU");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("X-Yandex-API-Key", "ТУТ ВСТАВИТЬ КЛЮЧ");
        var response = await client.GetAsync(request);

        string strResponce = response.Content;
        int startIndex = strResponce.IndexOf("fact") + 6;
        int endIndex = strResponce.IndexOf("\"forecasts\"") - 1;
        strResponce = strResponce.Substring(startIndex, endIndex - startIndex);

        WatherData wd = JsonConvert.DeserializeObject<WatherData>(strResponce);

        Console.WriteLine($"Температура: {wd.temp}°C (ощущается как {wd.feels_like}°C)");
        Console.WriteLine($"Скорость ветра: {wd.wind_speed} м/с");
        Console.WriteLine($"Скорость порывов ветра: {wd.wind_gust} м/с");
        Console.WriteLine($"Давление: {wd.pressure_mm} мм рт. ст.");
        Console.WriteLine($"Влажность воздуха: {wd.humidity}%");
    }

    class WatherData
    {
        public int temp { get; set; }
        public int feels_like { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public int pressure_mm { get; set; }
        public int humidity {  get; set; }
    }
}