using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuUIManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void OnClickStart()
    {
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
        SceneManager.LoadScene(3);
    }

    public void OnClickSettings()
    {
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
    }

    public void OnClickQuit()
    {
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
        Application.Quit();
    }

    
}
