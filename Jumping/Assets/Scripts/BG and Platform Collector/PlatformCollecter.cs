using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollecter : MonoBehaviour {

    //public GameObject panel;
    //private GameObject scoretext;
    //public GameObject pause, stoppause;
    //public Player player;
    //public SoundsManager sound;
    public GameController gameController;
    void Awake () {
        //panel = GameObject.Find("Pause Panel");
        //scoretext = GameObject.Find("Score Text");
        //pause = GameObject.Find("PauseButton");
        //stoppause = GameObject.Find("StopPauseButton");
        //stoppause.SetActive(false);
        //panel.SetActive(false);
    }
    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Platform")
        {
            col.gameObject.SetActive(false);
            //set lai van toc
            col.gameObject.GetComponent<Platform>().RandomMoment();
            ObjectPooler.Instance.AddToPool(col.gameObject);
           // Destroy(col.gameObject);
        }
        if(col.tag == "Player")
        {
           
            
            GameController.FirstTimeLoadSreen = false;
           // gameController.Invoke("ClickPlayAgain", 0.5f);
            gameController.ClickPlayAgain();
            //panel.SetActive(true);
            //scoretext.SetActive(false);
            //pause.SetActive(false);
            //stoppause.SetActive(false);
        }
    }
}
