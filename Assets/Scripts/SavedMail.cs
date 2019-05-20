using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedMail : HomeTestElement
{
    public Email myEmail;

    public void ShowMail()
    {
        app.home_menu.GOMailPanel();
        app.email_View.setData(myEmail, true);
    }
}
