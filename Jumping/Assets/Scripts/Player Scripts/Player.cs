using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public Rigidbody2D rb;
    public float jumpPower;
    public Button jumpBtn;
    private GameObject parent;


    public bool hasJump, platformBound;


    public delegate void MoveCamera();
    public static event MoveCamera move;


    public Text scoreText;
    public static int score = 0;

    public int ran;


    public SoundsManager sound;
    public GameObject jumpEffect;

    public Image timerBar;
    public float maxTime = 5f;
    public float timeLeftUI;

    public int bonusScore = 0;
    public Text bonusScoreText;

    public float timeleft;

    public float diamond = 0;

    [HideInInspector]
    public int Bestscore;
    //Bien nay dung de dieu khien anim o cac object con
    public bool jumpAnim = true;

    public Text starText;
    //private float timeBtnEffect;
    //public float startTimeEffect;

    public GameController GameController;


    private void Awake()
    {

        diamond = PlayerPrefs.GetFloat("diamond");
        
        //Debug.Log(PlayerPrefs.GetFloat("diamond"));
        jumpBtn.onClick.AddListener(() => Jump());

        scoreText.text = score.ToString();


        timeLeftUI = 0;
    }
    // Update is called once per frame
    private void Start()
    {
       
    }

    
    void Update()
    {
        if (hasJump && rb.velocity.y == 0)
        {
            if (!platformBound)
            {
                //bonus score base
                bonusScore++;
                StopCoroutine("countTimer");
                StartCoroutine("countTimer");
                sound.Playsound("hitscore");
                //end
                hasJump = false;
                score+=bonusScore;
                timeLeftUI = maxTime;
                transform.SetParent(parent.transform);
                GameController.instance.CreatePlatform();
                GameController.instance.CreateClound();
                jumpAnim = false;
                if (move != null)
                {
                    move();
                }
                
            }
            else if (parent != null)
            {
                transform.SetParent(parent.transform);
            }
        }
        if (bonusScore <= 0)
        {
            StopCoroutine("countTimer");
        }
        if (timeLeftUI >= 0)
        {
            timeLeftUI -= Time.deltaTime;
            timerBar.fillAmount = timeLeftUI / maxTime;
            timerBar.color = Color.Lerp(Color.red, Color.white, timerBar.fillAmount);
        }
        if(bonusScore >= 2)
        {
            bonusScoreText.text = "X" + bonusScore.ToString();
        }
        else
        {
            bonusScoreText.text = "";
        }

        if(Bestscore < score)
        {
            Bestscore++;
        }
        scoreText.text = Bestscore.ToString();
        starText.text = PlayerPrefs.GetFloat("diamond").ToString();
    }
    
 
    IEnumerator countTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeleft);
            bonusScore = 0;
        }
    }
    public void Jump()
    {
        if (rb.velocity.y == 0)
        {
            sound.Playsound("jump");
            rb.velocity = new Vector2(0, jumpPower);
            transform.SetParent(null);
            jumpAnim = true;
           // ran = Random.Range(0, 2);
            
            hasJump = true;
            Instantiate(jumpEffect, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("FirstPlatform"))
        {
            jumpAnim = false;
            
            //anim.SetBool("Idle", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform" && rb.velocity.y == 0)
        {
            parent = col.gameObject;
            jumpAnim = false;
            Instantiate(jumpEffect, transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            parent = null;
        }
        if (col.gameObject.CompareTag("FirstPlatform"))
        {
            jumpAnim = true;
            Instantiate(jumpEffect, transform.position, Quaternion.identity);
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MainCamera")
        {
            platformBound = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "MainCamera")
        {
            platformBound = false;
        }
    }
}
