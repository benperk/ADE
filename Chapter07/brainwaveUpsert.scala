// Databricks notebook source
import org.apache.spark.sql._
import io.delta.tables._

Seq.empty[(Long, Timestamp, Long, String)]
  .toDF("Offset", "Time", "Timestamp", "Body")
  .write.format("delta").mode("overwrite").saveAsTable("brainwaves")

var detlaTable = DeltaTable.forName("brainwaves")

val incomingStream = spark.readStream.format("eventhubs")
  .options(customEventhubParameters.toMap).load()

val messages =
  incomingStream
  .withColumn("Offset", $"offset".cast(LongType))
  .withColumn("Time (readable)", $"enqueuedTime".cast(TimestampType))
  .withColumn("Timestamp", $"enqueuedTime".cast(LongType))
  .withColumn("Body", $"body".cast(StringType))
  .select("Offset", "Time (readable)", "Timestamp", "Body")

incomingStream.writeStream.format("delta").foreachBatch(
  deltaTable.as("bw").merge(messages.as("m"), "m.Time = bw.Time")
  .whenMatched().updateAll()
  .whenNotMatched().insertAll()
  .execute()
).outputMode("update").start()

//messages.createOrReplaceTempView("updates")
//messages.sql("""
//  MERGE INTO brainwaves bw
//  USING updates u
//  ON u.Time = bw.Time
//  WHEN MATCHED THEN UPDATE *
//  WHEN NOT MATCHED THEN INSERT *
//""")
