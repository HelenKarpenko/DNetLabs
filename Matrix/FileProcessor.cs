using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace MatrixLib
{
    public static class FileProcessor
    {
        public static void ToBinary(Matrix matrix, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, matrix);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public static Matrix FromBinary(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                
                Matrix matrix = (Matrix)formatter.Deserialize(fs);

                return matrix;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        //public static void ToJSON(Matrix matrix, string fileName)
        //{
        //    DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Matrix));

        //    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        try
        //        {
        //            formatter.WriteObject(fs, matrix);
        //        }
        //        catch (SerializationException e)
        //        {
        //            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //            throw;
        //        }
        //    }
        //}

        //public static Matrix FromJSON(string fileName)
        //{
        //    DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Matrix));

        //    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        //    {
        //        try
        //        {
        //            Matrix matrix = formatter.ReadObject(fs) as Matrix;

        //            return matrix;
        //        }
        //        catch (SerializationException e)
        //        {
        //            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //            throw;
        //        }
        //    }
        //}
        
    }
}
