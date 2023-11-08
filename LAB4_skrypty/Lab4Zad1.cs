using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lab4Zad1 : MonoBehaviour
{
    public int numberOfObjects = 10; // Iloœæ obiektów do wygenerowania
    public GameObject block; // Obiekt do generowania
    public float delay = 3.0f; // OpóŸnienie miêdzy generacjami
    public Collider platformCollider;
    private List<Vector3> positions = new List<Vector3>();
    private int objectCounter = 0;
    // Start is called before the first frame update
    void Start()
    {

        Bounds bounds = platformCollider.bounds;



        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = UnityEngine.Random.Range(bounds.min.z, bounds.max.z);
            positions.Add(new Vector3(randomX, 5, randomZ)); // 5 to przyk³adowa wysokoœæ
        }

        // Uruchomiam Coroutine
        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            Instantiate(block, pos, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
