using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private Transform cam;

    private float speed = 6f;
    private float jumpForce = 2f;
    private float gravity = -20f;
    private float verticalVelocity;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private float interactionRange = 3f;
    private KeyCode interactionKey = KeyCode.E;

    private Interactable currentInteractable;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        DoMovement();

        if(Input.GetKeyDown(interactionKey))
        {
            if(currentInteractable != null)
            {
                PerformInteraction();
            }
        }
    }

    private void DoMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;

            if(Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity); // Calculate jump velocity
            }
        }

        verticalVelocity += gravity * Time.deltaTime; // Apply gravity

        if(direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.y = verticalVelocity;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        } else
        {
            // Apply only vertical velocity when not moving horizontally
            Vector3 moveDir = new Vector3(0f, verticalVelocity, 0f);
            controller.Move(moveDir * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            currentInteractable = interactable;
            currentInteractable.Highlight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable == currentInteractable)
        {
            currentInteractable.ResetHighlight();
            currentInteractable = null;
        }
    }

    private void PerformInteraction()
    {
        currentInteractable.Interact();
    }
}
