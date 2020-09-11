using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuUIManager : MonoBehaviour
{
    public GameObject settingspanel;
    public GameObject highscore;
     public GameObject soundmanager;
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
            settingspanel.SetActive(true);
    }

    public void OnClickQuit()
    {
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
        Application.Quit();
    }

    public void OnClickHighscore()
    {
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
            highscore.SetActive(true);
    }
   public void OnClickSoundManager()
    {
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
            soundmanager.SetActive(true);
    }
   public void OnClickClose()
    {
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
            soundmanager.SetActive(true);
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    
}
