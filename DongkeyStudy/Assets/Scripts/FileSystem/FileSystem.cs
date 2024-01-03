using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

public class FileSystem
{
    public static void WriteBinary(string path, string content)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
        {
            // 이진 데이터를 작성합니다.
            writer.Write(content);
        }
    }


    public static string ReadBinary(string path)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            return reader.ReadString();
        }
    }

    public static bool TryWriteXml<T>(string path,T t)
    {
        if (File.Exists(path))
            return false;

        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (TextWriter writer = new StreamWriter(path))
        {
            try
            {
                serializer.Serialize(writer, t);
            }
            catch ( Exception e)
            {
                return false;
            }

        }


        return true;
    }

    public static bool TryReadXml<T>(string path, out T t )
    {
        t = default;

        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (TextReader reader = new StreamReader(path))
        {
            try
            {
                T deserialized = (T)serializer.Deserialize(reader);

                t = deserialized;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        return true;
    }

    public static bool TryWriteJson(string path,object obj)
    {
        if (File.Exists(path))
            return false;

        var result = JsonConvert.SerializeObject(obj);
        File.WriteAllText(path, result);

        return true;
    }

    public static bool TryReadJson<T>(string path, out T t)
    {
        t = default;
        if (!File.Exists(path))
            return false;

        var jsonData = File.ReadAllText(path);

        try
        {
            T data = JsonConvert.DeserializeObject<T>(jsonData);
            t = data;
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }

    public static bool TryWriteCSV<T>(string path, ICollection<T> collection)
    {
        FileInfo file = new FileInfo(path);
        StringBuilder sb = new StringBuilder();

        if (file.Exists)
            return false;

        using (StreamWriter wr = new StreamWriter(path))
        {
            FieldInfo[] fieldInfos = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            int fieldCount = fieldInfos.Length;

            //Header
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    if (sb.Length > 0)
                        sb.Append(',');
                    sb.Append(fieldInfos[i].Name);
                }
                sb.Append('\n');
            }


            //Body
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    if (i > 0)
                        sb.Append(',');
                    sb.Append(fieldInfos[i].GetValue(enumerator.Current));
                }
                sb.Append('\n');
            }

            wr.Write(sb);
            wr.Close();
        }


        return true;
    }

    public static bool TryReadCSV<T>(string path, out string[,] dataList)
    {
        FileInfo file = new FileInfo(path);
        dataList = null;

        if (!File.Exists(path))
            return false;

        string[] strs = File.ReadAllLines(path);
        if (strs != null && strs.Length > 0)
        {
            int col = strs[0].Split(',').Length;
            int row = strs.Length;

            string[,] result = new string[row, col];
            int colCount = result.GetLength(0);
            for (int i = 0; i < colCount; i++)
            {
                int rowCount = result.GetLength(1);
                string[] split = strs[i].Split(',');
                for (int j = 0; j < rowCount; j++)
                {
                    result[i, j] = split[j];
                }
            }

            dataList = result;
            return true;
        }

        return false;
    }
}
