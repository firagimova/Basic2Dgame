using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Collider2D groundCheck;
    public Collider2D deathLine;
    
    public TextMeshProUGUI collectiblesText;
    private int collectiblesCount = 0;

    

    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;
    private bool grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        grounded = true;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (started)
        {
            if (jumping)
            {
                rb.velocity = new Vector2(moveHorizontal * speed, jumpForce);
                jumping = false;
            }
            else
            {
                rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
            }

            if (moveHorizontal > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveHorizontal < 0 && facingRight)
            {
                Flip();
            }

            anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (started && grounded && !jumping)
            {
                anim.SetTrigger("jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                started = true;
            }
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal != 0)
        {
            started = true;
            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

            if (moveHorizontal > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveHorizontal < 0 && facingRight)
            {
                Flip();
            }

            anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        }
         if (grounded && !jumping)
        {
            anim.SetBool("isgrounded", true);
            
        }
        else
        {
            anim.SetBool("isgrounded", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Next"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        if (collision.gameObject.CompareTag("collectibles"))
        {
            collectiblesCount++;
            collectiblesText.text = collectiblesCount.ToString();
            
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("dangers"))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }

    
}
