using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class highscore : MonoBehaviour
{
    public Text scoreDisplay;
    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    
    public string highscoreURL = "http://localhost/gameone/getData.php";
 
    void Start()
    {
        StartCoroutine(GetScores());
    }
 
   
 
    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        scoreDisplay.text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;
 
        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            scoreDisplay.text = hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
 
}