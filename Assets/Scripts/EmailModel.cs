using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AppData
{
    public AppData()
    {
        emails = new List<Email>();
    }

    public string myEmail;
    public string supportEmail;
    public List<Email> emails;
}

public class Email
{
    public string name;
    public string from;
    public string to;
    public string subject;
    public string content;

    public Email(string name, string from, string to, string subject, string content)
    {
        this.name = name;
        this.from = from;
        this.to = to;
        this.subject = subject;
        this.content = content;
    }
}

public class EmailModel
{
    private const string DATA_FILE_PATH = "Assets/StreamingAssets/data.json";

    // Path.Combine combines strings into a file path
    // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
     

    
    public string readFileAsString(string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new Exception(string.Format("file {0} does not exist", filepath));
        }
        var fileContent = File.ReadAllText(filepath);
        return fileContent;
    }

    public AppData readAllData()
    {
        // Read the emails json from a file
        var json = DataModel.Instance.readFileAsString(DATA_FILE_PATH);
        AppData data = DataModel.Instance.jsonStringToObject<AppData>(json);
        return data;
    }

    public void saveAllData(AppData data)
    {
        var json = DataModel.Instance.objectToJsonString(data);

        Debug.Log(json);

        DataModel.Instance.writeStringToFile(json, DATA_FILE_PATH);
    }


    public void saveEmail(Email email)
    {
        // Get all data
        var data = readAllData();

        data.emails.Add(email);

        // Generate an ID for the email
        saveAllData(data); 
    }

    public List<Email> GetAllEmails()
    {
        var data = readAllData();
        return data.emails;
    }
}
