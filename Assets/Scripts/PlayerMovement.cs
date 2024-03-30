using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float mouseX;
    public float rotationSpeed;
    public float maxSpeed;
    public float speed; 
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");

        float rotation = mouseX * rotationSpeed;
        transform.Rotate(Vector3.up, rotation * Time.deltaTime);
        //print(rb.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right * -1.0f * vertical * speed * Time.deltaTime);
        rb.AddForce(transform.forward * horizontal * speed * Time.deltaTime);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}