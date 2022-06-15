import sys
import datetime
from pyspark.sql import SparkSession

print("Processing...")

spark = SparkSession.builder.appName("ToAvro").getOrCreate()
readPath = 'abfss://' + sys.argv[3] + '.dfs.core.windows.net/' + sys.argv[2] + '/*' + sys.argv[1] + '*.json'
print(readPath)
df = spark.read.option("multiline","true").json(readPath)
df.show()

dt = datetime.datetime.now()
timeWritePath = str(dt.year) + '/' + str('%02d' % dt.month) + '/' + str('%02d' % dt.day) + '/' + dt.strftime("%H") + '/'
writePath = 'abfss://' + sys.argv[3] + '.dfs.core.windows.net/EMEA/brainjammer/out/' + timeWritePath
print(writePath)
fileName = sys.argv[1] + '-' + str('%02d' % dt.month) + str('%02d' % dt.day) + dt.strftime("%H") + str(dt.minute) + '.avro'
print(fileName)
print(writePath + fileName)

df.write.mode('overwrite').format("avro").save(writePath + fileName)
spark.read.format("avro").load(writePath + fileName).show()

print("Process complete.")
