using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {

    public SpriteRenderer rd;
	// Use this for initialization
	void Start () {
        rd.color = Random.ColorHSV();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
