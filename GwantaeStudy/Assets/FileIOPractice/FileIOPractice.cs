using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class FileStreamExamObject
{
    public string text;
    public int amount;

    public FileStreamExamObject(string _text, int _amount)
    {
        text = _text;
        amount = _amount;
    }
}
public class JsonTestObject
{
    public string name;
    public int age;
    public int speed;

    public JsonTestObject(string _name, int _age, int _speed)
    {
        name = _name;
        age = _age;
        speed = _speed;
    }
}

public class FileIOPractice : MonoBehaviour
{
    private void Awake()
    {
        // 각각의 파일 포멧 읽고 쓰기
        //StreamReadWriteTxt();
        //BinaryReadWriteTxt();
        //SaveObjectToFile();
        // 출처 https://fiftiesstudy.tistory.com/222#google_vignette


        //SaveJson();
        //LoadJson();


        //UseFileClassReadWrite();
        //UseFileClass_1();

    }
    private void Update()
    {
        //if (Input.GetKeyDown("w"))
        //{
        //    string filePath = Path.Combine(Application.streamingAssetsPath, "Example.txt");
        //    string message = "I Love Me!!! 105";
        //    UseDirectoryInfoWrite(filePath, message);
        //}
        //if (Input.GetKeyDown("r"))
        //{
        //    string filePath = Path.Combine(Application.streamingAssetsPath, "Example.txt");
        //    UseDirectoryInfoReader(filePath);
        //}
        // 출처 https://coderzero.tistory.com/entry/%EC%9C%A0%EB%8B%88%ED%8B%B0-%EC%8A%A4%ED%81%AC%EB%A6%BD%ED%8A%B8-%EC%86%8C%EC%8A%A4-%ED%85%8D%EC%8A%A4%ED%8A%B8txt-%ED%8C%8C%EC%9D%BC-%EC%9D%BD%EA%B3%A0-%EC%93%B0%EA%B8%B0
    }

    private void StreamReadWriteTxt()
    {
        // 세 번째 파라미터인 엑세스 부분에 리드를 지정하고 스트림 라이트에 넣어주면 엘러 발생
        FileStream test = new FileStream("Assets/FileIOPractice/Files/testFile.txt", FileMode.Create);
        StreamWriter streamWriter = new StreamWriter(test);
        streamWriter.Write(1 + " Hellow my name is Tae\n");
        streamWriter.Write(2 + " Hellow my name is Tae\n");
        streamWriter.Write(3 + " Hellow my name is Tae");
        streamWriter.Close();

        test = new FileStream("Assets/FileIOPractice/Files/testFile.txt", FileMode.Open);
        StreamReader streamReader = new StreamReader(test);
        Debug.Log(streamReader.ReadLine());
        streamReader.Close();

    }

    private void BinaryReadWriteTxt()
    {
        FileStream binarytest = new FileStream("Assets/FileIOPractice/Files/BinaryTest.txt", FileMode.Create);
        BinaryWriter binaryWriter = new BinaryWriter(binarytest);
        binaryWriter.Write("Whith cow");
        binaryWriter.Write(105);
        binaryWriter.Close();

        binarytest = new FileStream("Assets/FileIOPractice/Files/BinaryTest.txt", FileMode.Open);
        BinaryReader binaryReader = new BinaryReader(binarytest);
        Debug.Log(binaryReader.ReadString());
        Debug.Log(binaryReader.ReadInt32());
        binaryReader.Close();

    }
    /// 객체를 파일로 저장하기
    ///
    private void SaveObjectToFile()
    {
        FileStreamExamObject testObj = new FileStreamExamObject("im taegwan", 27);

        FileStream testFileStream = new FileStream("Assets/FileIOPractice/Files/SaveObjTest.dat", FileMode.Create);
        BinaryFormatter testBinaryFormetter = new BinaryFormatter();
        testBinaryFormetter.Serialize(testFileStream, testObj);
        testFileStream.Close();

        testFileStream = new FileStream("Assets/FileIOPractice/Files/SaveObjTest.dat", FileMode.Open);
        FileStreamExamObject testData = (FileStreamExamObject)testBinaryFormetter.Deserialize(testFileStream);
        Debug.Log(testData.text);
        Debug.Log(testData.amount);
    }



    private void UseDirectoryInfoWrite(string _filePath, string _message)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(_filePath));
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }
        FileStream fileStream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter streamWriter = new StreamWriter(fileStream, System.Text.Encoding.Unicode);
        streamWriter.WriteLine(_message);
        streamWriter.Close();
    }
    private string UseDirectoryInfoReader(string _filePath)
    {
        FileInfo fileInfo = new FileInfo(_filePath);
        string value = "";

        if (fileInfo.Exists)
        {
            StreamReader streamReader = new StreamReader(_filePath);
            value = streamReader.ReadToEnd();
            streamReader.Close();
        }
        else
        {
            value = "Non File";
        }
        return value;
    }


    private void SaveJson()
    {
        JsonTestObject jsonTestObj = new JsonTestObject("rlaxorhks", 27, 30);
        string json = JsonUtility.ToJson(jsonTestObj);
        Debug.Log(json);

        string fileName = "JsonExample";
        string path = Application.dataPath + "/FileIOPractice/Files/" + fileName + ".json";

        FileStream fileStream = new FileStream(path, FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    private void LoadJson()
    {
        string fileName = "JsonExample";
        string path = Application.dataPath + "/FileIOPractice/Files/" + fileName + ".json";

        FileStream fileStream = new FileStream(path, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);

        JsonTestObject jsonTestObj = JsonUtility.FromJson<JsonTestObject>(json);

        Debug.Log(jsonTestObj.name);
        Debug.Log(jsonTestObj.age);
        Debug.Log(jsonTestObj.speed);
    }


    private void UseFileClassReadWrite()
    {
        var file = File.Create("Assets/FileIOPractice/Files/FileClassTest.txt");
        StreamWriter wirter = new StreamWriter(file);
        wirter.Write("이렇게 사용해도 되는건가??");
        wirter.Close();

        file = File.OpenRead("Assets/FileIOPractice/Files/FileClassTest.txt");
        StreamReader reader = new StreamReader(file);
        Debug.Log(reader.ReadToEnd());
    }

    private void UseFileClass_1()
    {
        // Stream 은 인스턴스를 생성해야 하지만  File 을 사용하면 정적변수이기 때문에 인스턴스 생성을 안한다 .
        // 스트림 라이트 외에 방법이 없는?
        using (StreamWriter wirter = new StreamWriter(File.OpenWrite("Assets/FileIOPractice/Files/FileClassTest_1.txt")))
        {
            wirter.WriteLine("aakakakaka");
            
        }

        // ReadAllText를 사용하면 에러를 뱉음 나중에 확인
        using (StreamReader reader = new StreamReader(File.OpenRead("Assets/FileIOPractice/Files/FileClassTest_1.txt")))
        {
            Debug.Log(reader.ReadToEnd());
        }
    }

}
