using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed;

    public float upRotation;
    public float minRotation;

    CharacterController characterControl;
    public Transform playerCam;

    Vector3 vel;

    public float lookSensitivity;

    float xRotation = 0;

    float gravity = -10;
    float gravityScale = 1;
    float jumpHeight = 2;

    // Start is called before the first frame update
    void Start()
    {
        characterControl = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -upRotation, minRotation);
        playerCam.localRotation = Quaternion.Euler(xRotation, 0, 0);


        vel.z = Input.GetAxis("Vertical") * speed;
        vel.x = Input.GetAxis("Horizontal") * speed;

        if (characterControl.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vel.y = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
        }
        vel.y += gravity * gravityScale * Time.deltaTime;

        vel = transform.TransformDirection(vel);
        characterControl.Move(vel * Time.deltaTime);


    }
}
