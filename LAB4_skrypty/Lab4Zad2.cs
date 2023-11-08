using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab4Zad2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 10.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float mouseSensitivity = 100f;
    private float xRotation = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        // Zablokowanie kursora na œrodku ekranu i ukrycie go
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obrót postaci za pomoc¹ myszki
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Zastosuj obrót wokó³ osi X (góra/dó³) tylko dla kamery
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Obrót wokó³ osi Y (lewo/prawo) dla postaci
        transform.Rotate(Vector3.up * mouseX);

        // Reszta kodu ruchu
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
