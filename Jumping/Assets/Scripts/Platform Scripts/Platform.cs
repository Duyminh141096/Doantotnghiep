using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public float minX, maxX;
    public float minSpeed, maxSpeed;
    public bool moveleft;
    public float ranspeed;


	void Awake () {
        RandomMoment();
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    public void RandomMoment()
    {
        float ran = Random.Range(0, 2);
        if(ran == 0)
        {
            moveleft = true;
        }
        else if(ran == 1)
        {
            moveleft = false;
        }
        if(Player.score < 20 )
        ranspeed = Random.Range(0.5f, 1.5f);
        else if(Player.score < 50)
        {
            ranspeed = Random.Range(1, 2.5f);
        }
        else if(Player.score < 100)
        {
            ranspeed = Random.Range(0.5f, 3);
        }
        float ranScale = Random.Range(0.4f, 0.56f);
        transform.localScale = new Vector2(ranScale,0.5f);
    }
    private void Move()
    {
        if (moveleft)
        {
            Vector3 temp = transform.position;
            temp.x -= ranspeed * Time.deltaTime;
            transform.position = temp;
            
            if(transform.position.x < minX)
            {
                moveleft = false;
            }
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x += ranspeed * Time.deltaTime;
            transform.position = temp;

            if (transform.position.x > maxX)
            {
                moveleft = true ;
            }
        }
    }
}
