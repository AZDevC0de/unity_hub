using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

public class zad2 : MonoBehaviour
{
    public float speed = 2.0f;
    private float initialPositionX;
    private bool movingForward = true;
    


    private void Start()
    {
        initialPositionX = transform.position.x;
        //Debug.Log(initialPositionX);
    }

    private void Update()
    {
        if (movingForward)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= initialPositionX + 10)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= initialPositionX - 10)
            {
                movingForward = true;
            }
        }
    }
}