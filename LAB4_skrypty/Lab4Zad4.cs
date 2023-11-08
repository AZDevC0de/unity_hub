using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Lab4Zad4 : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Ograniczenie rotacji wok� osi X
        xRotation -= mouseYMove;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Zastosowanie ograniczonej rotacji do  kamery
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotacja wok� osi Y
        player.Rotate(Vector3.up * mouseXMove);
    }
}
