// Databricks notebook source
val rawReadings = "wasbs://brainjammer@csharpguitar.blob.core.windows.net/*.parquet"
val rawReadingsDF = spark.read.option("header","true").parquet(rawReadings)
rawReadingsDF.createOrReplaceTempView("TmpREADING")
spark.sql("SELECT * FROM TmpREADING").limit(5).show()

// COMMAND ----------

val MODE = "wasbs://brainjammer@csharpguitar.blob.core.windows.net/MODE.csv"
val ELECRODE = "wasbs://brainjammer@csharpguitar.blob.core.windows.net/ELECTRODE.csv"
val FREQUENCY = "wasbs://brainjammer@csharpguitar.blob.core.windows.net/FREQUENCY.csv"
val SCENARIO = "wasbs://brainjammer@csharpguitar.blob.core.windows.net/SCENARIO.csv"
val SESSION = "wasbs://brainjammer@csharpguitar.blob.core.windows.net/SESSIONALL.csv"

val MODEDF = spark.read.option("header","true").csv(MODE)
val ELECRODEDF = spark.read.option("header","true").csv(ELECRODE)
val FREQUENCYDF = spark.read.option("header","true").csv(FREQUENCY)
val SCENARIODF = spark.read.option("header","true").csv(SCENARIO)
val SESSIONDF = spark.read.option("header","true").csv(SESSION)

MODEDF.createOrReplaceTempView("MODE")
ELECRODEDF.createOrReplaceTempView("ELECTRODE")
FREQUENCYDF.createOrReplaceTempView("FREQUENCY")
SCENARIODF.createOrReplaceTempView("SCENARIO")
SESSIONDF.createOrReplaceTempView("SESSION")
spark.sql("SELECT COUNT(*) AS numSessions FROM SESSION").limit(5).show()
spark.sql("SELECT * FROM ELECTRODE").limit(5).show()

// COMMAND ----------

val BrainwavesDF = spark.sql("""
    SELECT  se.SESSION_DATETIME, r.READING_DATETIME, 
            s.SCENARIO, e.ELECTRODE, f.FREQUENCY, r.VALUE
    FROM    SESSION se, TmpREADING r, SCENARIO s, 
            ELECTRODE e, FREQUENCY f
    WHERE   r.SESSION_ID = se.SESSION_ID AND se.SCENARIO_ID = s.SCENARIO_ID 
            AND r.ELECTRODE_ID = e.ELECTRODE_ID AND r.FREQUENCY_ID = f.FREQUENCY_ID
""")
BrainwavesDF.select("SCENARIO", "ELECTRODE", "FREQUENCY", "VALUE").show(5)

// COMMAND ----------

val BrainwavesPath = "/FileStore/business-data/2022/04/30"
BrainwavesDF.write.format("delta").mode("overwrite").save(BrainwavesPath)
val BrainwavesDeltaPath = "/FileStore/business-data/2022/04/30"
val BrainwavesDeltaDF = spark.read.format("delta").load(BrainwavesDeltaPath)
print(BrainwavesDeltaDF.count())
BrainwavesDeltaDF.select("SCENARIO", "ELECTRODE", "FREQUENCY", "VALUE").show(5)

// COMMAND ----------

print(BrainwavesDeltaDF.count())
BrainwavesDeltaDF.select("SCENARIO", "ELECTRODE", 
                         "FREQUENCY", "VALUE").orderBy($"SCENARIO".desc).show(5)

// COMMAND ----------

display(BrainwavesDeltaDF.select("SCENARIO", "ELECTRODE", "FREQUENCY", "VALUE"))
