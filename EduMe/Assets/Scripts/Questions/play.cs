using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour {
	public string[] soal;
	public string[] jawaban;

	public Text text_soal, text_skor;
	public InputField input_jawaban;

	public GameObject feed_benar, feed_salah;

	int nomor_soal = -1;
    int skor=DBManager.score;
	public GameObject questionpanel;
	

	// Use this for initialization
	public void Start () {
	
        feed_benar.SetActive (false);
        feed_salah.SetActive (false);

		buka_soal ();
	}

	void buka_soal(){
		nomor_soal++;
		text_soal.text = soal [nomor_soal];
	}

	public void jawab(){
        
		if (nomor_soal < soal.Length-1) {
			if (input_jawaban.text == jawaban [nomor_soal]) {
				
				feed_benar.SetActive (true);
				feed_salah.SetActive (false);
				DBManager.score=DBManager.score+100;
				print(DBManager.score);
				  
				  Destroy(questionpanel);
				   
				
			} else {
				feed_benar.SetActive (false);
				
				feed_salah.SetActive (true);
			}
			buka_soal ();
			input_jawaban.text = "";
		} else {
			
			transform.GetChild(transform.childCount-1).gameObject.SetActive (false);
		}
		if (SoundManager.instance != null)
            SoundManager.instance.PlayButtonPressSound();
	}
	
	
	
	// Update is called once per frame
	void Update () {
		text_skor.text = skor.ToString ();
	}
}
