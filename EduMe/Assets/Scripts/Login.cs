﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;
    
    public void CallLogin()
    {
        
        StartCoroutine(LoginUser());
    }

    

    public  IEnumerator LoginUser()
    {
        WWWForm form= new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www= new WWW("http://localhost/gameone/LoginUser.php",form);
        yield return www;
        if(www.text[0]=='0')
        {
            DBManager.username=nameField.text;
            DBManager.score=int.Parse(www.text.Split('\t')[1]);
             DBManager.x=float.Parse(www.text.Split('\t')[2]);
              DBManager.y=float.Parse(www.text.Split('\t')[3]);
               DBManager.z=float.Parse(www.text.Split('\t')[4]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }

    }

    public void VerifyInputs()
    {
        submitButton.interactable=(nameField.text.Length>=4  && passwordField.text.Length>=6);
    }
}
