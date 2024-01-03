using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class testFileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WriteBinary("testBin.bin");
        ReadBinary("testBin.bin");

        //WriteXml("testXml.xml");
        //ReadXml("testXml.xml");

        //WriteJson("testJson.json");
        //ReadJson("testJson.json");

        //WriteCSV("test2.txt");
        //ReadCSV("test.csv");
    }

    private void WriteBinary(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";
        string content = "Hello World!";

        FileSystem.WriteBinary(path, content);
    }

    private void ReadBinary(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";

        string content = FileSystem.ReadBinary(path);
        Debug.Log(content);
    }

    private void WriteXml(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";
        testData data1 = new testData();
        data1.name = "Dongkey";
        data1.age = 19;
        data1.gender = "Male";


        if(!FileSystem.TryWriteXml<testData>(path, data1))
            Debug.LogError("Write Error");
    }

    private void ReadXml(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";
        testData data;


        if (!FileSystem.TryReadXml<testData>(path, out data))
        {
            Debug.LogError("Write Error");
            return;
        }

        Debug.Log(data.name);
        Debug.Log(data.age);
        Debug.Log(data.gender);
    }

    private void WriteJson(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";
        testData data1 = new testData();
        data1.name = "Dongkey";
        data1.age = 19;
        data1.gender = "Male";

        if (!FileSystem.TryWriteJson(path, data1))
            Debug.LogError("Write Error");

    }

    private void ReadJson(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";

        testData data;

        if(!FileSystem.TryReadJson<testData>(path,out data))
        {
            Debug.LogError("Read Error");
            return;
        }

        Debug.Log(data.name);
        Debug.Log(data.age);
        Debug.Log(data.gender);
    }

    private void WriteCSV(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";

        List<testData> datas = new List<testData>();
        testData data1 = new testData();
        data1.name = "Dongkey";
        data1.age = 19;
        data1.gender = "Male";
        datas.Add(data1);

        testData data2 = new testData();
        data2.name = "Dongkey2";
        data2.age = 12;
        data2.gender = "Male";
        datas.Add(data2);

        if (!FileSystem.TryWriteCSV<testData>(path, datas))
            Debug.LogError("Write Error");
    }

    private void ReadCSV(string fileName)
    {
        string path = $"{Application.dataPath}/Resources/FileSystem/{fileName}";
        string[,] datas;

        if (!FileSystem.TryReadCSV<testData2>(path, out datas))
            Debug.Log("Read Error");

        int colCount = datas.GetLength(0);
        int rowCount = datas.GetLength(1);
        for (int i= 0; i < colCount; i++)
        {
            for (int j = 0; j < rowCount; j++)
            {
                Debug.Log($"{i}행 {j}열 : {datas[i, j]} ");
            }
        }
    }
}
