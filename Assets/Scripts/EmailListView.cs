using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailListView : HomeTestElement
{
    public Button buttonPrefab;
    public Transform parent;

    public void showEmailList(List<Email> emails)
    {
        foreach (var email in emails)
        {
            Instantiate(buttonPrefab, parent);
            buttonPrefab.GetComponentInChildren<Text>().text = "subject:  " + email.content;
            buttonPrefab.GetComponent<SavedMail>().myEmail = email;
        }
    }

   
}
