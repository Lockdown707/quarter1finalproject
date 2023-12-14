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
    public bool canShoot;
    public float fireRate = 0.1f;
    public GameManager gameManager;

    public GameObject laserPrefab;

    public ParticleSystem deathParticle;

    public GameObject model;

    public bool isAlive = true;

    public AudioClip deathSound;
    private AudioSource playerAudio;

    

    //Animator
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        laserSpawn = rightSpawn;
        animator =model.GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        canShoot = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Switch Laser
        if(horizontalInput < 0 && isAlive)
        {
            laserSpawn = leftSpawn;
        }
        if(horizontalInput > 0 && isAlive)
        {
            laserSpawn = rightSpawn;
        }

        //Rotate Model
        if (horizontalInput < 0 && isAlive)
        {
            model.transform.forward = Vector3.left;
        }
        if (horizontalInput > 0 && isAlive)
        {
            model.transform.forward = Vector3.right;
        }


        // Move Forward
        if (isAlive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * speed);
            animator.SetFloat("HorizontalInput", Mathf.Abs(horizontalInput));

            // Jumping
            if (Input.GetButtonDown("Jump") && isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;

                animator.SetBool("isOnGround", isOnGround);
            }

            //Shooting
            if (Input.GetButtonDown("Fire1") && canShoot)
            {
                Instantiate(laserPrefab, laserSpawn.transform.position, laserSpawn.transform.rotation);
                canShoot = false;
                StartCoroutine(ShootDelay());
            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        animator.SetBool("isOnGround", isOnGround);

        //Game Over
        if (collision.gameObject.CompareTag("obstacle"))
        {
            deathParticle.Play();
            animator.SetTrigger("Death");
            isAlive = false;
            gameManager.GameOver();
            //Audio Death Sound
            playerAudio.PlayOneShot(deathSound);
        }

        //Particle Death
        
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}
