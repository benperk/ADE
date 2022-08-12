using System.Text;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

using static System.Console;

try
{
    WriteLine("Enter your Event Hub connection string:");
    var EventHubConnectionString = ReadLine();
    WriteLine("Enter your Event Hub Name string:");
    var EventHubName = ReadLine();

    EventHubProducerClient producerClient = new EventHubProducerClient(EventHubConnectionString, EventHubName);
    var json = "{\"FREQUENCY_ID\": 5, \"VALUE\":\"0.259\", \"READING_DATETIME\":\"2022-08-12 08:46:32\"}";
    EventData eventData = new EventData(Encoding.UTF8.GetBytes(json));
    WriteLine($"Sending data... JSON: {json}");
    eventData.Properties.Add("Format", "json");
    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
    eventBatch.TryAdd(eventData);
    await producerClient.SendAsync(eventBatch);
    WriteLine($"Data sucessfully sent.");
    WriteLine();
}
catch (Exception ex)
{
    WriteLine($"An exception happened: {ex.Message}");
}
WriteLine("Press any key to exit...");
ReadLine();
