Console.WriteLine("Select a city ");

string city = Console.ReadLine();

var client = new HttpClient();

var request = new HttpRequestMessage
{
	Method = HttpMethod.Get,
	RequestUri = new Uri($"https://open-weather13.p.rapidapi.com/city/{city}"),
	Headers =
	{
		{ "X-RapidAPI-Key", "ebf8fe15a0msh9347bf8a12ae3a9p114e9ajsn431be86ffa31" },
		{ "X-RapidAPI-Host", "open-weather13.p.rapidapi.com" },
	},
};

using (var response = await client.SendAsync(request))
{
	response.EnsureSuccessStatusCode();
	var body = await response.Content.ReadAsStringAsync();
    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(body);
    Console.WriteLine(data.main);
}
