using System;
using System.Data;
using System.IO;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace brainjammer_azuresql
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "<servername>.database.windows.net";
                builder.UserID = "<username>";
                builder.Password = "<password>";
                builder.InitialCatalog = "<database>";

                Brainwave brainwaves = LoadSession();

                int scenarioId = GetScenario(brainwaves.Session.Scenario);
                int modeId = 2; //POW
                DateTime sessionDateTime = (brainwaves.Session.POWReading[0].ReadingDate)
                                           .AddSeconds(-brainwaves.Session.POWReading[0].ReadingDate.Second)
                                           .AddMilliseconds(-brainwaves.Session.POWReading[0].ReadingDate.Millisecond);

                int sessionId = 0;
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO SESSION (SCENARIO_ID, MODE_ID, SESSION_DATETIME) " +
                                 "VALUES (@SCENARIO_ID, @MODE_ID, @SESSION_DATETIME); SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.Add("@SCENARIO_ID", SqlDbType.Int).Value = scenarioId;
                        cmd.Parameters.Add("@MODE_ID", SqlDbType.Int).Value = modeId;
                        cmd.Parameters.Add("@SESSION_DATETIME", SqlDbType.DateTime).Value = sessionDateTime;
                        cmd.CommandType = CommandType.Text;
                        sessionId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }                

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO READING (SESSION_ID, ELECTRODE_ID, FREQUENCY_ID, READING_DATETIME, COUNT, VALUE) " +
                                 "VALUES (@SESSION_ID, @ELECTRODE_ID, @FREQUENCY_ID, @READING_DATETIME, @COUNT, @VALUE) ";

                    foreach (var reading in brainwaves.Session.POWReading)
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;
                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF3");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("THETA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF3[0].THETA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF3");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("ALPHA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF3[0].ALPHA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF3");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_L");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF3[0].BETA_L;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF3");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_H");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF3[0].BETA_H;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF3");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("GAMMA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF3[0].GAMMA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF4");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("THETA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF4[0].THETA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF4");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("ALPHA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF4[0].ALPHA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF4");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_L");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF4[0].BETA_L;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF4");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_H");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF4[0].BETA_H;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("AF4");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("GAMMA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.AF4[0].GAMMA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T7");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("THETA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T7[0].THETA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T7");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("ALPHA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T7[0].ALPHA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T7");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_L");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T7[0].BETA_L;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T7");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_H");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T7[0].BETA_H;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T7");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("GAMMA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T7[0].GAMMA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T8");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("THETA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T8[0].THETA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T8");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("ALPHA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T8[0].ALPHA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T8");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_L");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T8[0].BETA_L;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T8");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_H");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T8[0].BETA_H;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("T8");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("GAMMA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.T8[0].GAMMA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("Pz");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("THETA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.Pz[0].THETA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("Pz");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("ALPHA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.Pz[0].ALPHA;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("Pz");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_L");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.Pz[0].BETA_L;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("Pz");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("BETA_H");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.Pz[0].BETA_H;
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            cmd.Parameters.Add("@SESSION_ID", SqlDbType.Int).Value = sessionId;
                            cmd.Parameters.Add("@READING_DATETIME", SqlDbType.DateTime).Value = reading.ReadingDate;
                            cmd.Parameters.Add("@COUNT", SqlDbType.Int).Value = reading.Counter;

                            cmd.Parameters.Add("@ELECTRODE_ID", SqlDbType.Int).Value = GetElectrode("Pz");
                            cmd.Parameters.Add("@FREQUENCY_ID", SqlDbType.Int).Value = GetFrequency("GAMMA");
                            cmd.Parameters.Add("@VALUE", SqlDbType.Decimal).Value = reading.Pz[0].GAMMA;
                            cmd.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Loaded reading #{reading.Counter} from {reading.ReadingDate}");
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine($"Finished...");
            Console.ReadLine();
        }
        static Brainwave LoadSession()
        {
            try
            {
                Brainwave brainwaves;
                using (StreamReader file = File
                    .OpenText(@"C:\Temp\csharpguitar\SessionJson\ClassicalMusic\POW\csharpguitar-brainjammer-pow-0937.json"))
                {
                    brainwaves = JsonConvert.DeserializeObject<Brainwave>(file.ReadToEnd());
                    Console.WriteLine($"Scenario of type: {brainwaves.Session.Scenario} successfully loaded, " +
                        $"with: {brainwaves.Session.POWReading.Count} readings... \n");
                }
                return brainwaves;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception happend: {ex.Message}");
                return null;
            }
        }
        //These values need to match the values on the database tables
        static int GetScenario(string scenario)
        {
            switch (scenario)
            {
                case "ClassicalMusic":
                    return 1;
                case "FlipChart":
                    return 2;
                case "Meditation":
                    return 3;
                case "MetalMusic":
                    return 4;
                case "PlayingGuitar":
                    return 5;
                case "TikTok":
                    return 6;
                case "WorkMeeting":
                    return 7;
                case "WorkNoEmail":
                    return 8;
                default:
                    return 0;
            }
        }
        static int GetElectrode(string electrode)
        {
            switch (electrode)
            {
                case "AF3":
                    return 1;
                case "AF4":
                    return 2;
                case "T7":
                    return 3;
                case "T8":
                    return 4;
                case "Pz":
                    return 5;
                default:
                    return 0;
            }
        }
        static int GetFrequency(string frequency)
        {
            switch (frequency)
            {
                case "THETA":
                    return 1;
                case "ALPHA":
                    return 2;
                case "BETA_L":
                    return 3;
                case "BETA_H":
                    return 4;
                case "GAMMA":
                    return 5;
                default:
                    return 0;
            }
        }
    }
}
