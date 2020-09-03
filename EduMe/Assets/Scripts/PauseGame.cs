using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
bool isPaused=false;
    public void pauseGame()
    {
        if(isPaused){
            Time.timeScale=1;
        }
        else{
            Time.timeScale=0;
        }
    }
}
