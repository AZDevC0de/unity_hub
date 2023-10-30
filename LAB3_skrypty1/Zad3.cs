using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad3 : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3[] points;
    private int currentPointIndex = 0;
    private Vector3 targetPoint;

    void Start()
    {
        
        points = new Vector3[4];
        points[0] = transform.position;
        points[1] = transform.position + new Vector3(10, 0, 0);
        points[2] = transform.position + new Vector3(10, 0, 10);
        points[3] = transform.position + new Vector3(0, 0, 10);

        targetPoint = points[1];
    }

    void Update()
    {
        
        Vector3 moveDirection = (targetPoint - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;

        
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            //obrot o 90 st
            transform.Rotate(0, 90, 0);

            
            currentPointIndex = (currentPointIndex + 1) % 4;
            targetPoint = points[currentPointIndex];
        }
    }
}