using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class play2 : MonoBehaviour
{
   public GameObject feed_benar, feed_salah;
   public Text playerDisplay;
	public Text scoreDisplay;
   public GameObject questionpanel2;
    void Start()
    {
        
     
    }
   public void jawaban(bool jawab){

            if (jawab) {
		
				feed_benar.SetActive (false);
				feed_benar.SetActive (true);
                
				DBManager.score=DBManager.score+100;
				playerDisplay.text="Player :" +DBManager.username;
                scoreDisplay.text="Score :" +DBManager.score;
				  
				 
				   
				
			} else {
				feed_salah.SetActive (false);
				
				feed_salah.SetActive (true);
                
			}
			gameObject.SetActive(false);
            transform.parent.GetChild(gameObject.transform.GetSiblingIndex () +1).gameObject.SetActive(true);
            
            
   }
     public void continueButton(){
       Destroy(questionpanel2);
     }   
	
    // Update is called once per frame
    void Update()
    {
        
    }
}

