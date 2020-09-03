using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject gameOverPanel;
    public GameObject levelClearPanel;
      public GameObject questionpanel;
    void start()
    {
        gameOverPanel.SetActive(false);
        instance= this;
        
        
    }

    
    public void OnClickRetry()
    {
        Time.timeScale=1;
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClickMain()
    {
        Time.timeScale=1;
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
        SceneManager.LoadScene("MainMenu");
    }
    public void OnClickQuit()
    {
        Time.timeScale=1;
        if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
        Application.Quit();
    }

    public void OnGameOver()
    {
     gameOverPanel.SetActive(true);
       Time.timeScale=0;
        if (SoundManager.instance != null)
            SoundManager.instance.PlayOverSound();
    }

    public void OnLevelClear()
    {
        levelClearPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnLevelQuestion()
    {
        questionpanel.SetActive(true);
    
    }
}
