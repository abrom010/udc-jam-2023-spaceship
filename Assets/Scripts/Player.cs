using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 10.0f;

    private CharacterController controller;
    private Vector3 movementDirection;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(controller.isGrounded) {
            movementDirection = speed * transform.TransformDirection(new Vector3(horizontal, 0, vertical));

            if(Input.GetButtonDown("Jump")) {
                movementDirection.y = jumpSpeed;
            }
        }

        movementDirection.y -= gravity * Time.deltaTime;

        controller.Move(movementDirection * Time.deltaTime);

        Vector3 rotationDirection = new Vector3(horizontal, 0, vertical);
        if(rotationDirection.magnitude > 0) {
            Quaternion toRotation = Quaternion.LookRotation(new Vector3(horizontal, 0, vertical));
            transform.GetChild(0).transform.rotation = Quaternion.Lerp(transform.GetChild(0).transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
