using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animControllerPlayer : MonoBehaviour {


    public Animator anim;
    public Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.jumpAnim == true)
        {
            if (player.ran == 0)
                anim.SetBool("Jump0", true);
            //else
            //    anim.SetBool("Jump1", true);
        }
        if (player.jumpAnim == false)
        {
            if (player.ran == 0)
                anim.SetBool("Jump0", false);
            //else
            //    anim.SetBool("Jump1", false);
        }
    }
}
