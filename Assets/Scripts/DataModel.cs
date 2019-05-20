using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DataModel
{
    private static DataModel _instance;
    public static DataModel Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataModel();
            }
            return _instance;
        }
    }

    public string objectToJsonString(object obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        return json;
    }

    public T jsonStringToObject<T>(string json)
    {
        T deserializedString = JsonConvert.DeserializeObject<T>(json);
        return deserializedString;
    }

    public void writeStringToFile(string fileContent, string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new Exception(string.Format("file {0} does not exist", filepath));
        }

        File.WriteAllText(filepath, fileContent);
    }

    public string readFileAsString(string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new Exception(string.Format("file {0} does not exist", filepath));
        }
        var fileContent = File.ReadAllText(filepath);
        return fileContent;
    }
}
