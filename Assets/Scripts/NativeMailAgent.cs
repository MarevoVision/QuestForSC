using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeMailAgent : MonoBehaviour {

    public string email, subject, body;

    public void SendEmail()
    {
        string emailSend = email;
        string subjectSend = MyEscapeURL(subject);
        string bodySend = MyEscapeURL(body);
        Application.OpenURL("mailto:" + emailSend + "?subject=" + subjectSend + "&body=" + bodySend);
    }
    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}
