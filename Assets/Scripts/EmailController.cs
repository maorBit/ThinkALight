using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EmailController : HomeTestElement
{
    // How to show and hide a view? and how to pass parameters
    // Where is the emails *list* view?
    // How to create a delegate (event) and register to it here
    [SerializeField] private GameObject EmailList;

    void Start()
    {
        app.email_View.OnSendEmail += OnSendEmail;
        //app.email_list_View.OnViewEmail(OnViewEmail);
        //app.email_list_View.OnNewEmail(OnNewEmail);
    }

    public void OnSendEmail(Email email)
    {
        app.home_menu.ShowMailListPanel();
        app.email_model.saveEmail(email);

        List<Email> emails = app.email_model.GetAllEmails();

        //app.email_View.hide();
        app.email_list_view.showEmailList(emails);
    }

    public void OnViewEmail(Email email)
    {
        //app.email_list_View.hide();

        //app.email_view.setData(email, true);
        //app.email_view.show(); 
    }

    //public void OnNewEmail(Email email)
    //{
    //    app.email_list_View.hide();
    //    app.email_view.show(emails, false); // isEditAllowed: 
    //}


}
