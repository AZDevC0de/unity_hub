
//using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;

    void Start()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-5, 5), 0.5f, Random.Range(-5, 5));
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }
}