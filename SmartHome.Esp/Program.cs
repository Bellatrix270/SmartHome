using Libraries;
using RestSharp;

Uart uart = new Uart();

#region DataFromUart

byte peopleCount = uart.Read();

#endregion

var options = new RestClientOptions("http://192.168.0.107:5139");
var client = new RestClient(options);
var request = new RestRequest("rooms")
    .AddBody(new {name = "Kitchen", peopleCount = peopleCount});
var response = client.Put(request);

int a = 5;