using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using System.IO;
using Newtonsoft.Json;

namespace brainjammer_cosmosdb
{
    class Program
    {
        private static readonly string EndpointUri = "https://<add your cosmosdb account name>.documents.azure.com:443/";
        private static readonly string PrimaryKey = "<add your key here>";
        private static CosmosClient cosmosClient;
        private static Database database;
        private static Container container;

        private static string databaseId = "brainjammer";
        private static string containerId = "sessions";

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Beginning operations... \n");
            try
            {
                cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
                await CreateDatabaseAsync();
                await CreateContainerAsync();
                await AddItemsToContainer();
                await QueryItemsAsync();

                Console.WriteLine("Operation complete... \n");
                Console.ReadLine();
            }
            catch (CosmosException cex)
            {
                Console.WriteLine($"{cex.StatusCode} error occurred: {cex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private static async Task CreateDatabaseAsync()
        {
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine($"Database: '{database.Id}' exists... \n");
        }
        private static async Task CreateContainerAsync()
        {
            container = await database.CreateContainerIfNotExistsAsync(containerId, "/pk");
            Console.WriteLine($"Container: '{container.Id}' exists... \n");
        }
        private static async Task QueryItemsAsync()
        {
            var sqlQueryText = "SELECT * FROM c";
            Console.WriteLine($"Running query: {sqlQueryText}\n");
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Brainwave> queryResultSetIterator = container.GetItemQueryIterator<Brainwave>(queryDefinition);

            List<Brainwave> brainwaves = new List<Brainwave>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Brainwave> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Brainwave wave in currentResultSet)
                {
                    brainwaves.Add(wave);
                    Console.WriteLine($"\t{wave.Partition}, {wave.Session.POWReading[0].ReadingDate}\n");
                }
            }
        }
        private static async Task AddItemsToContainer()
        {
            Brainwave brainwaves;
            try
            {
                List<string> sessions = new List<string>()
                {
                    @"C:\Temp\csharpguitar-brainjammer-pow-2134.json",
                    @"C:\Temp\csharpguitar-brainjammer-pow-2142.json"
                };
                foreach (var session in sessions)
                {
                    using (StreamReader file = File.OpenText(session))
                    {
                        brainwaves = JsonConvert.DeserializeObject<Brainwave>(file.ReadToEnd());
                        Console.WriteLine($"Scenario of type: {brainwaves.Session.Scenario} successfully loaded, " +
                            $"with: {brainwaves.Session.POWReading.Count} readings... \n");
                    }
                    brainwaves.Id = Guid.NewGuid().ToString();
                    brainwaves.Partition = brainwaves.Session.Scenario;
                    ItemResponse<Brainwave> brainwaveResponse = await container.CreateItemAsync<Brainwave>(brainwaves,
                        new PartitionKey(brainwaves.Partition));

                    Console.WriteLine($"HttpStatusCode: {brainwaveResponse.StatusCode}, " +
                    $"Session with type: {brainwaveResponse.Resource.Session.Scenario} " +
                    $"with: {brainwaveResponse.Resource.Session.POWReading.Count} readings... \n");
                }
            }
            catch (CosmosException cex)
            {
                //if the entry already exists you might get this exception
                Console.WriteLine($"HttpStatusCode: {cex.StatusCode}, Error: {cex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
