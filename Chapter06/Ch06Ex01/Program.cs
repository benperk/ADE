using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Azure;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Convert;

namespace brainjammer_batch
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string storageAccountName = string.Empty;
                string storageAccountContainerName = string.Empty;
                string inputLocation = string.Empty;
                string outputLocation = string.Empty;
                string accountKey = string.Empty;
                DataLakeServiceClient dataLakeServiceClient = null;

                if (args.Length > 0)
                {
                    storageAccountName = args[0];
                    storageAccountContainerName = args[1];
                    inputLocation = args[2];
                    outputLocation = args[3];
                    accountKey = args[4];

                    outputLocation = outputLocation + 
                        $"/{DateTime.Now.Year}/{DateTime.Now.Month.ToString("d2")}/{DateTime.Now.Day}/{DateTime.Now.ToString("HH")}";

                    WriteLine("Arguments provided from command line...");
                    WriteLine($"storageAccountName: {storageAccountName}");
                    WriteLine($"storageAccountContainerName: {storageAccountContainerName}");
                    WriteLine($"inputLocation: {inputLocation}");
                    WriteLine($"outputLocation: {outputLocation}");
                    WriteLine($"accountKey: ***********");

                    StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, accountKey);
                    string dfsUri = "https://" + storageAccountName + ".dfs.core.windows.net";
                    dataLakeServiceClient = new DataLakeServiceClient(new Uri(dfsUri), sharedKeyCredential);
                }
                else
                {
                    throw new InvalidOperationException("No instructions provided, I do not know what to do, please pass required cmd arguments...  Bye.");
                }

                DataLakeFileSystemClient fileSystemClient = dataLakeServiceClient.GetFileSystemClient(storageAccountContainerName);
                IAsyncEnumerator<PathItem> enumerator = fileSystemClient.GetPathsAsync(inputLocation).GetAsyncEnumerator();
                await enumerator.MoveNextAsync();
                PathItem item = enumerator.Current;
                while (item != null)
                {
                    Brainwave brainwaves = await LoadSession(item.Name, fileSystemClient);
                    string Scenario = brainwaves.Session.Scenario.ToString();
                    WriteLine($"The current scenario is: {Scenario}.");
                    List<double> gTHETAList = new List<double>();
                    List<double> gALPHAList = new List<double>();
                    List<double> gBETA_LList = new List<double>();
                    List<double> gBETA_HList = new List<double>();
                    List<double> gGAMMAList = new List<double>();
                    double gTHETA = 0, gALPHA = 0, gBETA_L = 0, gBETA_H = 0, gGAMMA = 0;
                    WriteLine("Processing started...");
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

                        double minimum = 0.274;
                        int maximum = 392;

                        if (new[] { THETA, ALPHA, BETA_L, BETA_H, GAMMA }.Max() < maximum &&
                            new[] { THETA, ALPHA, BETA_L, BETA_H, GAMMA }.Min() > minimum)
                        {
                            gTHETAList.Add(THETA);
                            gALPHAList.Add(ALPHA);
                            gBETA_LList.Add(BETA_L);
                            gBETA_HList.Add(BETA_H);
                            gGAMMAList.Add(GAMMA);
                        }
                    }
                    gTHETA = Median(gTHETAList);
                    gALPHA = Median(gALPHAList);
                    gBETA_L = Median(gBETA_LList);
                    gBETA_H = Median(gBETA_HList);
                    gGAMMA = Median(gGAMMAList);
                    WriteLine("Processing completed.");
                    string identifierFile = DateTime.Now.ToString("HH:mm:ss.FFFFF").Replace(":", "").Replace(".", "");
                    string fileName = "csharpguitar-brainjammer-pow-" + Scenario + "-" + identifierFile + ".json";
                    WriteLine($"Attempting to write: {outputLocation}/{fileName}");
                    var data = new JObject(
                               new JProperty("ALPHA", gALPHA),
                               new JProperty("BETA_H", gBETA_H),
                               new JProperty("BETA_L", gBETA_L),
                               new JProperty("GAMMA", gGAMMA),
                               new JProperty("THETA", gTHETA)).ToString();

                    await UploadFile(fileSystemClient, outputLocation, fileName, data);

                    if (!await enumerator.MoveNextAsync())
                    {
                        break;
                    }
                    item = enumerator.Current;
                }              
            }
            catch (Exception ex)
            {
                WriteLine($"An exception happend: {ex.Message}");
            }
        }
        static async Task<Brainwave> LoadSession(string fileName, DataLakeFileSystemClient fileSystemClient)
        {
            Brainwave brainwaves = new Brainwave();
            try
            {
                DataLakeFileClient fileClient = fileSystemClient.GetFileClient(fileName);
                Response<FileDownloadInfo> downloadResponse = await fileClient.ReadAsync();
                StreamReader file = new StreamReader(downloadResponse.Value.Content);
                brainwaves = JsonConvert.DeserializeObject<Brainwave>(file.ReadToEnd());                                
                WriteLine($"File: {fileName} was successfully retrieved.");
                return brainwaves;
            }
            catch (Exception ex)
            {
                WriteLine($"An exception happend: {ex.Message}");
                return brainwaves;
            }
        }
        static double Median(List<double> values)
        {
            double[] valuesArray = values.ToArray();
            Array.Sort(valuesArray);
            return Math.Round(values[valuesArray.Length / 2], 4);
        }
        static async Task UploadFile(DataLakeFileSystemClient fileSystemClient, string outputLocation, string fileName, string data)
        {
            DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(outputLocation);
            DataLakeFileClient fileClient = await directoryClient.CreateFileAsync(fileName);
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            MemoryStream memoryStream = new MemoryStream(buffer);
            long fileSize = memoryStream.Length;
            await fileClient.AppendAsync(memoryStream, offset: 0);
            await fileClient.FlushAsync(position: fileSize);
            WriteLine($"File: {outputLocation}/{fileName} was written successfully. Size: {fileSize} bytes.");
        }
    }
}
