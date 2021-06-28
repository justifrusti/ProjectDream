using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float normalSpeed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float minX = -60f;
    public float maxX = 60f;
    public float sensitivity;
    float rotY = 0f;
    float rotX = 0f;

    private Vector3 moveDirection = Vector3.zero;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Character Movement
        if(characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            //Jump
            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        //Running
        if(Input.GetButtonDown("Sprint"))
        {
            speed = runSpeed;
        }else if (Input.GetButtonUp("Sprint"))
        {
            speed = normalSpeed;
        }

        //Camera Movement
        rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotX += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, minX, maxX);

        transform.localEulerAngles = new Vector3(0, rotY, 0);
        cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);
    }
}
