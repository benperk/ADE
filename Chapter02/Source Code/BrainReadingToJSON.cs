using System;
using System.Threading;
using System.IO;
using System.Collections;
using System.Text;
using CortexAccess;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace BandPowerLogger
{
    public class POWData
    {
        public string Scenario { get; set; }
        public DateTime ReadingDate { get; set; }
        public int Counter { get; set; }
        public List<Brainwave> AF3 { get; set; }
        public List<Brainwave> T7 { get; set; }
        public List<Brainwave> Pz { get; set; }
        public List<Brainwave> T8 { get; set; }
        public List<Brainwave> AF4 { get; set; }
    }
    public class Brainwave
    {
        public decimal THETA { get; set; }
        public decimal ALPHA { get; set; }
        public decimal BETA_L { get; set; }
        public decimal BETA_H { get; set; }
        public decimal GAMMA { get; set; }
    }
    public enum Scenarios
    {
        WorkNoEmail,
        WorkEmail,
        WorkMeeting,
        Meditation,
        PlayingGuitar,
        MetalMusic,
        ClassicalMusic,
        TikTok,
        FlipChart,
        Testing
    }
    class Program
    {
        private static string OutFilePath = @"BandPowerLogger.csv";
        private static string identifierFolder = DateTime.Now.ToString("HH:mm").Replace(":", "");
        private static FileStream OutFileStream;
        private static POWData brainWaves = new POWData();
        private static int brainwaveCounter = 0;
        private static List<POWData> readings = new List<POWData>();
        static void Main(string[] args)
        {
            Console.WriteLine("BAND POWER LOGGER");
            Console.WriteLine("Please wear Headset with good signal!!!");

            Console.WriteLine("Enter the scenario which you are recording: ");
            brainWaves.Scenario = Console.ReadLine();

            //Write to CSV
            string filePath = @"C:\Temp\csharpguitar\SessionCSV\" + brainWaves.Scenario + @"\POW\";
            string identifier = DateTime.Now.ToString("HH:mm").Replace(":", "");
            string fileName = "csharpguitar-brainjammer-pow-" + brainWaves.Scenario + "-" + identifier + ".csv";
            OutFilePath = filePath + fileName;
            CheckLogDirectory(filePath);

            // Delete Output file if existed
            if (File.Exists(OutFilePath))
            {
                File.Delete(OutFilePath);
            }
            OutFileStream = new FileStream(OutFilePath, FileMode.Append, FileAccess.Write);

            DataStreamExample dse = new DataStreamExample();
            dse.AddStreams("pow");
            dse.OnSubscribed += SubscribedOK;
            dse.OnBandPowerDataReceived += OnBandPowerOK;
            dse.Start();

            Console.WriteLine("Press Esc to flush data to file and exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }

            //Write JSON session file
            Console.WriteLine("Writting session JSON file...");
            JSONPerPOWSession(readings);

            // Unsubcribe stream
            dse.UnSubscribe();
            Thread.Sleep(5000);

            // Close Session
            dse.CloseSession();
            Thread.Sleep(5000);
            // Close Out Stream
            OutFileStream.Dispose();
        }
        private static void SubscribedOK(object sender, Dictionary<string, JArray> e)
        {
            foreach (string key in e.Keys)
            {
                if (key == "pow")
                {
                    // print header
                    ArrayList header = e[key].ToObject<ArrayList>();
                    //add timeStamp to header
                    header.Insert(0, "Timestamp");
                    WriteDataToFile(header);
                }
            }
        }
        // Write Header and Data to File
        private static void WriteDataToFile(ArrayList data)
        {
            int i = 0;
            for (; i < data.Count - 1; i++)
            {
                byte[] val = Encoding.UTF8.GetBytes(data[i].ToString() + ", ");

                if (OutFileStream != null)
                    OutFileStream.Write(val, 0, val.Length);
                else
                    break;
            }
            // Last element
            byte[] lastVal = Encoding.UTF8.GetBytes(data[i].ToString() + "\n");
            if (OutFileStream != null)
                OutFileStream.Write(lastVal, 0, lastVal.Length);
        }
        private static void OnBandPowerOK(object sender, ArrayList eegData)
        {
            brainWaves.Counter = brainwaveCounter;
            brainWaves.ReadingDate = DateTime.Now;
            brainWaves.AF3 = new List<Brainwave>()
            {
                new Brainwave { THETA = Convert.ToDecimal(eegData[1]),
                                ALPHA = Convert.ToDecimal(eegData[2]),
                                BETA_L = Convert.ToDecimal(eegData[3]),
                                BETA_H = Convert.ToDecimal(eegData[4]),
                                GAMMA = Convert.ToDecimal(eegData[5])}
            };
            brainWaves.T7 = new List<Brainwave>()
            {
                new Brainwave { THETA = Convert.ToDecimal(eegData[6]),
                                ALPHA = Convert.ToDecimal(eegData[7]),
                                BETA_L = Convert.ToDecimal(eegData[8]),
                                BETA_H = Convert.ToDecimal(eegData[9]),
                                GAMMA = Convert.ToDecimal(eegData[10])}
            };
            brainWaves.Pz = new List<Brainwave>()
            {
                new Brainwave { THETA = Convert.ToDecimal(eegData[11]),
                                ALPHA = Convert.ToDecimal(eegData[12]),
                                BETA_L = Convert.ToDecimal(eegData[13]),
                                BETA_H = Convert.ToDecimal(eegData[14]),
                                GAMMA = Convert.ToDecimal(eegData[15])}
            };
            brainWaves.T8 = new List<Brainwave>()
            {
                new Brainwave { THETA = Convert.ToDecimal(eegData[16]),
                                ALPHA = Convert.ToDecimal(eegData[17]),
                                BETA_L = Convert.ToDecimal(eegData[18]),
                                BETA_H = Convert.ToDecimal(eegData[19]),
                                GAMMA = Convert.ToDecimal(eegData[20])}
            };
            brainWaves.AF4 = new List<Brainwave>()
            {
                new Brainwave { THETA = Convert.ToDecimal(eegData[21]),
                                ALPHA = Convert.ToDecimal(eegData[22]),
                                BETA_L = Convert.ToDecimal(eegData[23]),
                                BETA_H = Convert.ToDecimal(eegData[24]),
                                GAMMA = Convert.ToDecimal(eegData[25])}
            };

            //Write every reading to file 
            List<POWData> reading = new List<POWData>();
            reading.Add(new POWData()
            {
                Scenario = brainWaves.Scenario,
                ReadingDate = DateTime.Now,
                Counter = brainWaves.Counter,
                AF3 = brainWaves.AF3,
                T7 = brainWaves.T7,
                Pz = brainWaves.Pz,
                T8 = brainWaves.T8,
                AF4 = brainWaves.AF4,
            });
            JSONPerPOWReading(reading);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Scenario: {brainWaves.Scenario}");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            foreach (var wave in brainWaves.AF3)
            {
                Console.WriteLine($"AF3.THETA: {wave.THETA}, AF3.ALPHA: {wave.ALPHA}, AF3.BETA_L: {wave.BETA_L}, AF3.BETA_H: {wave.BETA_H}, AF3.GAMMA: {wave.GAMMA}");
            }
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            foreach (var wave in brainWaves.T7)
            {
                Console.WriteLine($"T7.THETA: {wave.THETA}, T7.ALPHA: {wave.ALPHA}, T7.BETA_L: {wave.BETA_L}, T7.BETA_H: {wave.BETA_H}, T7.GAMMA: {wave.GAMMA}");
            }
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            foreach (var wave in brainWaves.Pz)
            {
                Console.WriteLine($"Pz.THETA: {wave.THETA}, Pz.ALPHA: {wave.ALPHA}, Pz.BETA_L: {wave.BETA_L}, Pz.BETA_H: {wave.BETA_H}, Pz.GAMMA: {wave.GAMMA}");
            }
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            foreach (var wave in brainWaves.T8)
            {
                Console.WriteLine($"T8.THETA: {wave.THETA}, T8.ALPHA: {wave.ALPHA}, T8.BETA_L: {wave.BETA_L}, T8.BETA_H: {wave.BETA_H}, T8.GAMMA: {wave.GAMMA}");
            }
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            foreach (var wave in brainWaves.AF4)
            {
                Console.WriteLine($"AF4.THETA: {wave.THETA}, AF4.ALPHA: {wave.ALPHA}, AF4.BETA_L: {wave.BETA_L}, AF4.BETA_H: {wave.BETA_H}, AF4.GAMMA: {wave.GAMMA}");
            }
            Console.ResetColor();

            //load reading for session JSON files 
            readings.Add(new POWData()
             {
                 Scenario = brainWaves.Scenario,                 
                 ReadingDate = DateTime.Now,
                 Counter = brainWaves.Counter,
                 AF3 = brainWaves.AF3,
                 T7 = brainWaves.T7,
                 Pz = brainWaves.Pz,
                 T8 = brainWaves.T8,
                 AF4 = brainWaves.AF4,
             });

            WriteDataToFile(eegData);
            brainwaveCounter++;
        }
        public static void JSONPerPOWReading(List<POWData> reading)
        {
            string filePath = @"C:\Temp\csharpguitar\IndividualJson\" + brainWaves.Scenario + @"\pow-" + identifierFolder + @"\";
            string identifierFile = DateTime.Now.ToString("HH:mm:ss.FFFFF").Replace(":", "");
            string fileName = "csharpguitar-brainjammer-pow-" + identifierFile + ".json";

            try
            {
                var data =
                    new JObject(
                        new JProperty("Session",
                            new JObject(
                                new JProperty("Scenario", brainWaves.Scenario),
                                new JProperty("POWReading",
                                    new JArray(
                                        from r in reading
                                        orderby r.Counter
                                        select new JObject(
                                                   new JProperty("ReadingDate", r.ReadingDate),
                                                   new JProperty("Counter", r.Counter),
                                                   new JProperty("AF3", 
                                                       new JArray(
                                                           from af3 in r.AF3
                                                           select new JObject(
                                                                      new JProperty("THETA", af3.THETA),
                                                                      new JProperty("ALPHA", af3.ALPHA),
                                                                      new JProperty("BETA_L", af3.BETA_L),
                                                                      new JProperty("BETA_H", af3.BETA_H),
                                                                      new JProperty("GAMMA", af3.GAMMA)
                                                                      ))),
                                                      new JProperty("T7",
                                                          new JArray(
                                                              from t7 in r.T7
                                                              select new JObject(
                                                                         new JProperty("THETA", t7.THETA),
                                                                         new JProperty("ALPHA", t7.ALPHA),
                                                                         new JProperty("BETA_L", t7.BETA_L),
                                                                         new JProperty("BETA_H", t7.BETA_H),
                                                                         new JProperty("GAMMA", t7.GAMMA)
                                                                         ))),
                                                      new JProperty("Pz",
                                                          new JArray(
                                                              from pz in r.Pz
                                                              select new JObject(
                                                                         new JProperty("THETA", pz.THETA),
                                                                         new JProperty("ALPHA", pz.ALPHA),
                                                                         new JProperty("BETA_L", pz.BETA_L),
                                                                         new JProperty("BETA_H", pz.BETA_H),
                                                                         new JProperty("GAMMA", pz.GAMMA)
                                                                         ))),
                                                      new JProperty("T8",
                                                          new JArray(
                                                              from t8 in r.T8
                                                              select new JObject(
                                                                         new JProperty("THETA", t8.THETA),
                                                                         new JProperty("ALPHA", t8.ALPHA),
                                                                         new JProperty("BETA_L", t8.BETA_L),
                                                                         new JProperty("BETA_H", t8.BETA_H),
                                                                         new JProperty("GAMMA", t8.GAMMA)
                                                                         ))),
                                                      new JProperty("AF4",
                                                          new JArray(
                                                              from af4 in r.AF4
                                                              select new JObject(
                                                                         new JProperty("THETA", af4.THETA),
                                                                         new JProperty("ALPHA", af4.ALPHA),
                                                                         new JProperty("BETA_L", af4.BETA_L),
                                                                         new JProperty("BETA_H", af4.BETA_H),
                                                                         new JProperty("GAMMA", af4.GAMMA)
                                                                         )))
                                                   )))))).ToString();

                if (CheckLogDirectory(filePath))
                {
                    File.WriteAllText(filePath + fileName, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error happened in JSONPerPOWReading(): {ex.Message}");
            }
        }
        public static void JSONPerPOWSession(List<POWData> readings)
        {
            string filePath = @"C:\Temp\csharpguitar\SessionJson\" + brainWaves.Scenario + @"\POW\";
            string identifier = DateTime.Now.ToString("HH:mm").Replace(":", "");
            string fileName = "csharpguitar-brainjammer-pow-" + identifier + ".json";

            try
            {
                var data =
                    new JObject(
                        new JProperty("Session",
                            new JObject(
                                new JProperty("Scenario", brainWaves.Scenario),
                                new JProperty("POWReading",
                                    new JArray(
                                        from r in readings
                                        orderby r.Counter
                                        select new JObject(
                                                   new JProperty("ReadingDate", r.ReadingDate),
                                                   new JProperty("Counter", r.Counter),
                                                   new JProperty("AF3",
                                                       new JArray(
                                                           from af3 in r.AF3
                                                           select new JObject(
                                                                      new JProperty("THETA", af3.THETA),
                                                                      new JProperty("ALPHA", af3.ALPHA),
                                                                      new JProperty("BETA_L", af3.BETA_L),
                                                                      new JProperty("BETA_H", af3.BETA_H),
                                                                      new JProperty("GAMMA", af3.GAMMA)
                                                                      ))),
                                                      new JProperty("T7",
                                                          new JArray(
                                                              from t7 in r.T7
                                                              select new JObject(
                                                                         new JProperty("THETA", t7.THETA),
                                                                         new JProperty("ALPHA", t7.ALPHA),
                                                                         new JProperty("BETA_L", t7.BETA_L),
                                                                         new JProperty("BETA_H", t7.BETA_H),
                                                                         new JProperty("GAMMA", t7.GAMMA)
                                                                         ))),
                                                      new JProperty("Pz",
                                                          new JArray(
                                                              from pz in r.Pz
                                                              select new JObject(
                                                                         new JProperty("THETA", pz.THETA),
                                                                         new JProperty("ALPHA", pz.ALPHA),
                                                                         new JProperty("BETA_L", pz.BETA_L),
                                                                         new JProperty("BETA_H", pz.BETA_H),
                                                                         new JProperty("GAMMA", pz.GAMMA)
                                                                         ))),
                                                      new JProperty("T8",
                                                          new JArray(
                                                              from t8 in r.T8
                                                              select new JObject(
                                                                         new JProperty("THETA", t8.THETA),
                                                                         new JProperty("ALPHA", t8.ALPHA),
                                                                         new JProperty("BETA_L", t8.BETA_L),
                                                                         new JProperty("BETA_H", t8.BETA_H),
                                                                         new JProperty("GAMMA", t8.GAMMA)
                                                                         ))),
                                                      new JProperty("AF4",
                                                          new JArray(
                                                              from af4 in r.AF4
                                                              select new JObject(
                                                                         new JProperty("THETA", af4.THETA),
                                                                         new JProperty("ALPHA", af4.ALPHA),
                                                                         new JProperty("BETA_L", af4.BETA_L),
                                                                         new JProperty("BETA_H", af4.BETA_H),
                                                                         new JProperty("GAMMA", af4.GAMMA)
                                                                         )))
                                                   )))))).ToString();

                if (CheckLogDirectory(filePath))
                {
                    File.WriteAllText(filePath + fileName, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error happened in JSONPerPOWSession(): {ex.Message}");
            }
        }
        public static bool CheckLogDirectory(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error happened: {ex.Message}");
                return false;
            }
        }
    }
}
