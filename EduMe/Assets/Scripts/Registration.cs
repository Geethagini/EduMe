using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
     public InputField age;
    public Button submitButton;
    
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

  public  IEnumerator Register()
    {
        WWWForm form= new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("age", age.text);
        WWW www= new WWW("http://localhost/gameone/RegisterUser.php",form);
        yield return www;
        if(www.text[0]=='0')
        {
            Debug.Log("User created successfully");
             UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("User creation failed. Error #" +www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable=(nameField.text.Length>=4  && passwordField.text.Length>=5);
    }
}
