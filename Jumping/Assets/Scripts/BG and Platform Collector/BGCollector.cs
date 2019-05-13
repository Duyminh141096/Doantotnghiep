using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour {

    private GameObject[] bgs;
    private float firstY;
	// Use this for initialization
	void Awake () {
        bgs = GameObject.FindGameObjectsWithTag("Background");
        firstY = bgs[0].transform.position.y;
        for(int i = 1;i < bgs.Length; i++)
        {
            if(firstY < bgs[i].transform.position.y)
            {
                firstY = bgs[i].transform.position.y;
            }
        }
	}

  
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag== "Background")
        {
            Vector3 temp = col.transform.position;
            float height = ((BoxCollider2D)col).size.y;
            temp.y = firstY + height;
            col.transform.position = temp;
            firstY = temp.y;
        }
        if(col.tag == "Clound")
        {
            Destroy(col.gameObject);
        }
    }
}
