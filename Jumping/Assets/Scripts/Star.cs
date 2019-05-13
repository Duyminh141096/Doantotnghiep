using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    public Animator anim;
    [HideInInspector]
    //public Player player;
    public float diamond;
    public SoundsManager sounds;
	void Start () {
        UpdateDiamond();
        sounds = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundsManager>();
	}
	
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            UpdateDiamond();
            diamond++;
            sounds.Playsound("bonusscore");
            PlayerPrefs.SetFloat("diamond", diamond);
            anim.SetBool("Destroy", true);
            Destroy(gameObject, 0.4f);
        }
    }
    void UpdateDiamond()
    {
        diamond = PlayerPrefs.GetFloat("diamond");
    }

}
