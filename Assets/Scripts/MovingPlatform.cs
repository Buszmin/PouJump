using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool moveRight=true;
    public float speed=1f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(moveRight)
        {
            if (transform.position.x < 2.7)
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
            else
            {
                moveRight = false;
            }    
        }
        else
        {
            if (transform.position.x > -2.7)
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
