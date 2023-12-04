using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float jumpForce;
    private Rigidbody rb;
    public bool isOnGround = true;
    public float speed;

    public GameObject rightSpawn;
    public GameObject leftSpawn;
    public GameObject laserSpawn;


    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        laserSpawn = rightSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Forward
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * speed);
        
        // Jumping
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        //Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserPrefab,laserSpawn.transform.position, laserSpawn.transform.rotation);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
