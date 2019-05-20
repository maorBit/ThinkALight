using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Base class for all elements in this application.
public class HomeTestElement : MonoBehaviour
{
    // Gives access to the application and all instances.
    public HomeTestApp app { get { return GameObject.FindObjectOfType<HomeTestApp>(); } }
}

public class HomeTestApp : MonoBehaviour
{
    public EmailModel email_model;
    public EmailView email_View;
    public EmailController email_Controller;
    public EmailListView email_list_view;

    public DataModel data_model;
    public HomeMenu home_menu;

    private void Awake()
    {
        email_model = new EmailModel();
        data_model = new DataModel();

        home_menu = FindObjectOfType<HomeMenu>();
        email_View = FindObjectOfType<EmailView>();
        email_Controller = FindObjectOfType<EmailController>();
        email_list_view = FindObjectOfType<EmailListView>();
    }
}
