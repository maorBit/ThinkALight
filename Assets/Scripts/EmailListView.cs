using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailListView : HomeTestElement
{
    public Button buttonPrefab;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showEmailList(List<Email> emails)
    {
        foreach (var email in emails)
        {
            Instantiate(buttonPrefab, parent);
            buttonPrefab.GetComponentInChildren<Text>().text = "subject:  " + email.subject;
            buttonPrefab.GetComponent<SavedMail>().myEmail = email;
        }
    }

   
}
