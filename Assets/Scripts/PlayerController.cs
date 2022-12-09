using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] ParticleSystem particles;
    [SerializeField] Animator animator;
    public GameObject anchor;
    [SerializeField] Collider2D col;
    [SerializeField] GameObject deathScreen;

    [Header("Settings")]
    [SerializeField] float horizontalSpeed = 1;
    [SerializeField] float maxHorizontalSpeed = 1;
    [SerializeField] float jumpForce = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isVelocityUp();

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if(transform.position.x >=  3.35f)
        {
            transform.position = new Vector3(-3.35f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -3.35f)
        {
            transform.position = new Vector3(3.35f, transform.position.y, transform.position.z);
        }
    }

    public void MoveRight()
    {
        if (rb.velocity.x < maxHorizontalSpeed)
        {
            rb.AddForce(Vector2.right * horizontalSpeed, ForceMode2D.Force);
        }
    }

    public void MoveLeft()
    {
        if (rb.velocity.x > -maxHorizontalSpeed)
        {
            rb.AddForce(Vector2.left * horizontalSpeed, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SuperPad"))
        {
            particles.Play();
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce * 5, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("JumpPad"))
        {
            particles.Play();
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce * 2, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
           // collision.gameObject.GetComponent<Platform>().colliderSleep();
            particles.Play();
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        if (collision.gameObject.CompareTag("DeathZone"))
        {
            deathScreen.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public bool isVelocityUp()
    {
        if (PlayerController.Instance.rb.velocity.y > 0)
        {
            col.enabled = false;
            return true;
        }
        else
        {
            col.enabled = true;
            return false;
        }    
    }
}
