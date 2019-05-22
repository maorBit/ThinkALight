using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class EmailView : HomeTestElement
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _from;
    [SerializeField] private Text _subject;
    [SerializeField] private Text _content;

    [SerializeField] private string sendToEmail;
    [SerializeField] private Text _to;

    private Email currentEmailFile;
    private Text[] textFields;

    public Button sendButton;

    [SerializeField] private Text errorText;

    public delegate void SendEmail(Email email);
    public event SendEmail OnSendEmail;

    void Start()
    {
        textFields = new Text[] { _name, _from, _subject, _content };
        _to.text = sendToEmail;

        sendButton.onClick.AddListener(onSubmitClicked);
    }
    public void setData(Email email, bool isReadOnly)
    {
        sendButton.enabled = !isReadOnly;
        _subject.GetComponentInParent<InputField>().enabled = !isReadOnly;
        _from.GetComponentInParent<InputField>().enabled = !isReadOnly;
        _name.GetComponentInParent<InputField>().enabled = !isReadOnly;
        _content.GetComponentInParent<InputField>().enabled = !isReadOnly;
        
        if (email != null)
        {
            _subject.text = email.subject;
            _from.text = email.from;
            _name.text = email.name;
            _content.text = email.content;
        }
    }

    private void onSubmitClicked()
    {
        var isValid = validateForm();
        if (isValid)
        {
            string er = "Email Sent Successfully!";

            StartCoroutine(showErrorMessage(er));

            Email email = generateEmailFromValues();
            if (OnSendEmail != null)
            {
                OnSendEmail(email);
            }
        }
    }

    public bool validateForm() // calls from send button to chek if all fields are correct
    {
        foreach (var textField in textFields)
        {
            if (textField.text == "")
            {
                string er = "all fields must fill !!";
                StartCoroutine(showErrorMessage(er));
                return false;
            }
        }

        var error = ValidateEmails();
        if (error != null)
        {
            StartCoroutine(showErrorMessage(error));
            return false;
        }

        return true;
    }

    public Email generateEmailFromValues()
    {
        Email newEmail = new Email(_name.text, _from.text, _to.text, _subject.text, _content.text);
        return newEmail;
    }

    public bool isValidEmail(string email)
    {
        //var atSignIndex = email.IndexOf('@');
        //return atSignIndex > 0;
        //  email.IndexOf('.') > atSignIndex || atSignIndex > 0 && email.IndexOf('.') < atSignIndex && email.IndexOf('.') > atSignIndex;

        string pattern = null;
        pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        if (Regex.IsMatch(email, pattern))
        {
           Debug.Log("Valid Email address ");
            return true;

        }
        else
        {
            Debug.Log("Not a valid Email address ");
            return false;
        }
    }

    public string ValidateEmails()
    {
        string error = null;

        if (!isValidEmail(_from.text))
        {
            Debug.Log("'From' must be a valid email");
            return "'From' must be a valid email";
        }

        return error;
    }

    private IEnumerator showErrorMessage(string error)
    {
        errorText.enabled = true;
        errorText.text = error;

        yield return new WaitForSeconds(3f);

        errorText.enabled = false;

    }

}
