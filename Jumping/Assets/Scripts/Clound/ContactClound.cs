using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactClound : MonoBehaviour {

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        int ran = Random.Range(0, 3);
        if (col.CompareTag("Player"))
        {
            if(ran == 0)
            anim.SetTrigger("Contactt");
            else
            {
                if (ran == 1)
                {
                    anim.SetTrigger("Contactt1");
                }
                else
                {
                    if (ran == 2)
                    {
                        anim.SetTrigger("Contactt2");
                    }
                }
            } 
        }
    }
}
