using UnityEngine;

public class Lab5Zad1 : MonoBehaviour
{
    public Transform targetPosition; 
    public float speed = 2.0f; 
    private Vector3 startPosition; 
    private bool moveToTarget = false; 

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        if (moveToTarget)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

            
            if (transform.position == targetPosition.position)
            {
                moveToTarget = false; 
            }
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveToTarget = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            // moveToTarget = false;
        }
    }
}