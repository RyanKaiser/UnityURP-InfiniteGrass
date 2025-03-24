using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBallController : MonoBehaviour
{
    public Transform cameraTransform;

    public float movementSpeed = 10;
    public float rotationSpeed = 10;

    public float maxSpeed = 10f;
    public float moveForce = 500f;
    public float jumpForce = 100f;

    private Rigidbody rb;

    private Vector3 cameraOffset;
    void Start()
    {
        cameraOffset = cameraTransform.position - transform.position;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.isKinematic = !rb.isKinematic;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;
        if (movement != Vector3.zero && rb.linearVelocity.magnitude < maxSpeed)
        {
            Debug.Log("AddForce()");
            rb.AddForce(movement * (moveForce * Time.fixedDeltaTime));
        }


        //
        // rb.AddForce(cameraTransform.forward * Input.GetAxis("Vertical") * 0.1f, ForceMode.VelocityChange);
        // rb.AddForce(cameraTransform.right * Input.GetAxis("Horizontal") * 0.1f, ForceMode.VelocityChange);
        //
        // cameraTransform.position = transform.position + cameraOffset;
        //
        // float r = 0;
        //
        // if (Input.GetKey(KeyCode.E))
        //     r = 1;
        //
        // if (Input.GetKey(KeyCode.Q))
        //     r = -1;
        //
        // cameraTransform.rotation *= Quaternion.Euler(0, r * rotationSpeed, 0);
    }
}
