using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab5Zad3 : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public int currentWaypointIndex = 0; 
    public float speed = 2.0f; 
    private bool movingForward = true;
    
    void Start()
    {

    }

    void Update()
    {
        if (waypoints.Count == 0) return; 

        
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], speed * Time.deltaTime);

        // Sprawdzam cy dotar³a do waypointa
        if (transform.position == waypoints[currentWaypointIndex])
        {
            if (movingForward)
            {
                // nastêpny waypoint
                if (currentWaypointIndex < waypoints.Count - 1)
                {
                    currentWaypointIndex++;
                }
                else
                {
                    // kierunek na przeciwny
                    movingForward = false;
                    currentWaypointIndex--;
                }
            }
            else
            {
                // poprzedni waypoint
                if (currentWaypointIndex > 0)
                {
                    currentWaypointIndex--;
                }
                else
                {
                    // kierunek na przeciwny
                    movingForward = true;
                    currentWaypointIndex++;
                }
            }
        }
    }

    
    public void AddWaypoint(Vector3 newWaypoint)
    {
        waypoints.Add(newWaypoint);
    }

    

}
