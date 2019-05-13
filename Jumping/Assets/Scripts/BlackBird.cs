using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : MonoBehaviour
{
    public float minX, maxX;
    public float minY, maxY;
    public float speed;
    //public bool moveLeft;
    public int MoveLeft;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition();
    }
    Vector3 randomPositionY(float a)
    {
        Vector3 temp = new Vector3(a, Random.Range(minY, maxY), 0);
        return temp;
    }
    public void SpawnPosition()
    {
        MoveLeft = Random.Range(0, 2);
        if (MoveLeft == 0)
        {
            transform.position = randomPositionY(minX);
         
        }
        else
        {
            transform.position = randomPositionY(maxX);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //neu Moveleft == 0 
        if (MoveLeft == 0)
        {
            if (transform.position.x < maxX)
            {
                Vector3 temp = transform.position;
                temp.x += Time.deltaTime * speed;
                transform.position = temp;
            }
            else
            {
                ScaleCharacter();
                transform.position = randomPositionY(transform.position.x);
                MoveLeft = 1;

            }
        }
        else
        {
            if (transform.position.x > minX)
            {
                Vector3 temp = transform.position;
                temp.x -= Time.deltaTime * speed;
                transform.position = temp;
            }
            else
            {
                ScaleCharacter();
                transform.position = randomPositionY(transform.position.x);
                MoveLeft = 0;
            }
        }
    }
    void ScaleCharacter()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
