using System.Text;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Console;

namespace brainjammer
{
    internal class Program
    {
        private const string connectionString = "...";
        private const string eventHubName = "brainwaves";
        static EventHubProducerClient producerClient;
        static async Task Main()
        {
            try
            {
                WriteLine("Enter your Event Hub connection string:");
                var EventHubConnectionString = ReadLine();
                WriteLine("Enter your Event Hub Name string:");
                var EventHubName = ReadLine();
                WriteLine("Enter the path and name of brainwave session file:");
                var sessionPath = ReadLine();

                producerClient = new EventHubProducerClient(EventHubConnectionString, EventHubName);

                Brainwave brainwaves = LoadSession(sessionPath);
                int counter = 0;
                foreach (var reading in brainwaves.Session.POWReading)
                {
                    double THETA = 0, ALPHA = 0, BETA_L = 0, BETA_H = 0, GAMMA = 0;
                    THETA = ((double)reading.AF3[0].THETA + (double)reading.AF4[0].THETA + (double)reading.T7[0].THETA
                                 + (double)reading.T8[0].THETA + (double)reading.Pz[0].THETA) / 5;

                    ALPHA = ((double)reading.AF3[0].ALPHA + (double)reading.AF4[0].ALPHA + (double)reading.T7[0].ALPHA
                            + (double)reading.T8[0].ALPHA + (double)reading.Pz[0].ALPHA) / 5;

                    BETA_L = ((double)reading.AF3[0].BETA_L + (double)reading.AF4[0].BETA_L + (double)reading.T7[0].BETA_L
                             + (double)reading.T8[0].BETA_L + (double)reading.Pz[0].BETA_L) / 5;

                    BETA_H = ((double)reading.AF3[0].BETA_H + (double)reading.AF4[0].BETA_H + (double)reading.T7[0].BETA_H
                             + (double)reading.T8[0].BETA_H + (double)reading.Pz[0].BETA_H) / 5;

                    GAMMA = ((double)reading.AF3[0].GAMMA + (double)reading.AF4[0].GAMMA + (double)reading.T7[0].GAMMA
                            + (double)reading.T8[0].GAMMA + (double)reading.Pz[0].GAMMA) / 5;

                    var data = new JObject(
                               new JProperty("pk", brainwaves.Session.Scenario),
                               new JProperty("ReadingDate", reading.ReadingDate),
                               new JProperty("ALPHA", Math.Round(ALPHA, 4)),
                               new JProperty("BETA_H", Math.Round(BETA_H, 4)),
                               new JProperty("BETA_L", Math.Round(BETA_L, 4)),
                               new JProperty("GAMMA", Math.Round(GAMMA, 4)),
                               new JProperty("THETA", Math.Round(THETA, 4))).ToString();
                    EventData eventData = new EventData(Encoding.UTF8.GetBytes(data));
                    WriteLine($"Sending brainwave reading #{brainwaves.Session.POWReading[counter].Counter}. JSON: {data}");
                    eventData.Properties.Add("Format", "json");
                    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                    eventBatch.TryAdd(eventData);

                    ////BEGIN - add partitionKey
                    //IEnumerable<EventData> eventDataList = new List<EventData>() { eventData };
                    //CancellationToken cancellationToken = new CancellationToken();
                    //SendEventOptions eventOptions = new SendEventOptions() { PartitionKey = "pkBrainwaves" };
                    //await producerClient.SendAsync(eventDataList, eventOptions, cancellationToken);
                    ////END - add partitionKey

                    await producerClient.SendAsync(eventBatch);
                    WriteLine($"Brainwave reading #{brainwaves.Session.POWReading[counter].Counter} was sent sucessfully.");
                    WriteLine();
                    System.Threading.Thread.Sleep(200); //ingest 5 reading per second
                    counter++;
                }
                WriteLine($"All {counter} brainwave readings for this session have been sent...");
            }
            finally
            {
                await producerClient.DisposeAsync();
            }
            WriteLine("Press any key to exit...");
            ReadLine();
        }
        static Brainwave LoadSession(string sessionPath)
        {
            try
            {
                Brainwave brainwaves;
                using (StreamReader file = File.OpenText(@sessionPath))
                {
                    brainwaves = JsonConvert.DeserializeObject<Brainwave>(file.ReadToEnd());
                    WriteLine($"Scenario of type: {brainwaves.Session.Scenario} successfully loaded, " +
                        $"with: {brainwaves.Session.POWReading.Count} readings... \n");
                }
                return brainwaves;
            }
            catch (Exception ex)
            {
                WriteLine($"An exception happend: {ex.Message}");
                return null;
            }
        }
    }
}
