using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace WetterApp;

class Program {

    static void Main(string[] args)
    {
        Console.WriteLine("Die aktuelle Temperatur in welcher Stadt möchtest du wissen?");
        string city = Console.ReadLine();

        HttpClient httpClient = new HttpClient();
        string requestUrl = "https://api.openweathermap.org/data/2.5/weather?q="+city+"&appid=98fddd6a43823c753014981b0c01911b&units=metric";
        HttpResponseMessage httpResponse = httpClient.GetAsync(requestUrl).Result;
        string response = httpResponse.Content.ReadAsStringAsync().Result;
        WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(response);
        Console.WriteLine("In " + city + " hat es aktuell " + weatherMapResponse.main.temp + "°C");
        Console.ReadKey();
    }
}


class WeatherMapResponse
    {
        public Main main;
    }




class Main
{
    public float temp;
}




















