using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float jumpForce;
    private Rigidbody rb;
    public bool isOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Forward
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput);
        
        // Jumping
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
