using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour {

    private bool canMove;
    public float distance = 4.1f;
    public float newDestination;
    public float timeMovingCamera = 3f;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update () {
        MoveCamera();
	}
    private void OnEnable()
    {
        Player.move += Move;
    }
    private void OnDisable()
    {
        Player.move -= Move;
    }
    private void MoveCamera()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.y += timeMovingCamera * Time.deltaTime;
            transform.position = temp;
            if(transform.position.y >= newDestination)
            {
                canMove = false;
            }
        }
    }
    void Move()
    {
        newDestination = transform.position.y + distance;
        canMove = true; 
    }
}
