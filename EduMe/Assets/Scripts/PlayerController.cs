using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float walkSpeed;
	public bool grounded;
    public float jumpForce=300f;
    public UIManager uIManager;

    private Rigidbody2D rbd;
	private Animator anim;

    public Text playerDisplay;
	public Text scoreDisplay;
    public GameObject friend;
    
     void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
         transform.position = new Vector3(DBManager.x,DBManager.y,DBManager.z);
        print(DBManager.username);
        print(DBManager.x);
        SavePosition();
    }

        
    private void Awake()
    {
        if(DBManager.username==null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
            playerDisplay.text="Player :" +DBManager.username;
            scoreDisplay.text="Score :" +DBManager.score;
           
    }

    public void updatenewscore()
    {
        if(DBManager.username==null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
            playerDisplay.text="Player :" +DBManager.username;
            scoreDisplay.text="Score :" +DBManager.score;
           
    }



    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
        
         StartCoroutine(SavePosition());
    
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form= new WWWForm();
       
        form.AddField("name", DBManager.username);
        form.AddField("score",DBManager.score);
        form.AddField("coins",DBManager.coins);
        WWW www= new WWW("http://localhost/gameone/savedata.php",form);
        yield return www;
        if(www.text[0]=='0')
        {
            Debug.Log("Game Saved");
           
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
            
        }
DBManager.LogOut();
    
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
      
   public IEnumerator SavePosition() {
       WWWForm form= new WWWForm();
       
         form.AddField("name", DBManager.username);
         form.AddField("x", transform.position.x.ToString("0.00"));
         form.AddField("y", transform.position.y.ToString("0.00"));
         form.AddField("z", transform.position.z.ToString("0.00"));
        WWW www= new WWW("http://localhost/gameone/Insertpos.php",form);
        yield return www;
        if(www.text[0]=='0')
        {
            Debug.Log("Game position Saved");
           
        }
        else
        {
            Debug.Log("Save position failed. Error #" + www.text);
            
        }
     }

    
    

    

    // Update is called once per frame
    void Update()
    {
         float x = Input.GetAxis("Horizontal");
         anim.SetFloat("Speed", Mathf.Abs(x));
        anim.SetBool("Grounded", grounded);
          if (x > 0)
            transform.localScale = Vector2.one;
        else if (x < 0)
            transform.localScale = new Vector2(-1, 1);
         rbd.velocity = new Vector2(x * walkSpeed, rbd.velocity.y);

         
        if (Input.GetKeyDown(KeyCode.Space))
        {
              Jump();
        }

        //if(transform.position.y <=-7f)
       // {
           // anim.SetTrigger("Death");
          //  uIManager.OnGameOver();
           
        //}
    }

    public void Jump ()
	{
		if(grounded)
		{
            if (SoundManager.instance != null)
                SoundManager.instance.PlayJumpSound();
            rbd.AddForce(Vector2.up*jumpForce);
		}
	}
    void OnTriggerEnter2D(Collider2D target)
	{
      if(target.gameObject.tag=="Coin")
	  {
            if (SoundManager.instance != null)
                SoundManager.instance.PlayCoinSound();
            CoinManager.instance.UpdateCoin();
            DBManager.score=DBManager.score+50;
            
		scoreDisplay.text="Score:"+DBManager.score;
		  Destroy(target.gameObject);
	  }
      else if(target.gameObject.tag=="Spike")
      {
            if (SoundManager.instance != null)
                SoundManager.instance.PlayOverSound();
            anim.SetTrigger("Death");
          uIManager.OnGameOver();
      }

        else if (target.gameObject.name == "Door")
        {
             if (SoundManager.instance != null)
                SoundManager.instance.levelcomplete();
             uIManager.OnLevelClear();
        }
        else if (target.gameObject.name == "friend1")
        {
            Destroy(target.gameObject);
              uIManager.OnLevelQuestion();
              
               SavePlayerData();
            
           
             
        }
    }

    
}
