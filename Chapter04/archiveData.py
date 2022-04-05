from pyspark.sql import SparkSession

# prepare spark session
spark = SparkSession.builder.appName('archiveBrainwaveData').getOrCreate()

# create a spark context
sc = spark.sparkContext

# set ADLS file system URI
sc._jsc.hadoopConfiguration().set('fs.defaultFS', 'abfss://brainjammer@csharpguitar.dfs.core.windows.net/')
hadoop_config = sc._jsc.hadoopConfiguration()

# instantiate the FileSystem manager
fs = (sc._jvm.org.apache.hadoop.fs.FileSystem.get(hadoop_config))

# enter the ADLS endpoint and path
endpoint = hadoop_config.get('fs.defaultFS')
print("fs.defaultFS –>", endpoint)
path = "EMEA/brainjammer/" + sys.argv[1] + "/" + sys.argv[2] + "/" + sys.argv[3] + "/" + sys.argv[4]  
print("path –>", path)
if (fs.exists(sc._jvm.org.apache.hadoop.fs.Path(endpoint + path))):
      # Delete the file or directory in ADLS
      deletion_status = fs.delete(sc._jvm.org.apache.hadoop.fs.Path(endpoint + path), True)
      print("Deletion status –>", deletion_status)
      # check whether the file or directory got deleted 
      # this will return True if exists and False if does not
      status = fs.exists(sc._jvm.org.apache.hadoop.fs.Path(endpoint + path))
      print("Status –>", status)
else:
      # notify the file or directory does not exist
      print("Status –> path does not exist")
