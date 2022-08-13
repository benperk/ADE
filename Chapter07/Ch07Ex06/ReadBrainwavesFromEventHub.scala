// Databricks notebook source
import org.apache.spark.eventhubs.{ConnectionStringBuilder, EventHubsConf}

val eventHubName = "..."
val eventHubNSConnStr = "Endpoint=sb://..."
val connStr = ConnectionStringBuilder(eventHubNSConnStr).setEventHubName(eventHubName).build

val customEventhubParameters = EventHubsConf(connStr).setMaxEventsPerTrigger(5)
val incomingStream = spark.readStream.format("eventhubs").options(customEventhubParameters.toMap).load()

val messages =
  incomingStream
  .withColumn("Offset", $"offset".cast(LongType))
  .withColumn("Time (readable)", $"enqueuedTime".cast(TimestampType))
  .withColumn("Timestamp", $"enqueuedTime".cast(LongType))
  .withColumn("Body", $"body".cast(StringType))
  .select("Offset", "Time (readable)", "Timestamp", "Body")

messages.writeStream.outputMode("append").format("console").option("truncate", false).start().awaitTermination()
