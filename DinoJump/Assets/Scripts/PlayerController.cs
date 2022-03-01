using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField] private float force;
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;

    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if (horizontalInput != 0f)
        {
            playerAnimator.SetBool("isWalking", true);
            Move();
        }
        else 
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    void Jump()
    {
        gameObject.transform.SetParent(null);
        playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        playerAnimator.SetBool("isJumping", true);
        isGrounded = false;
    }

    void Move()
    {
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Good"))
        {
            isGrounded = true;
            playerAnimator.SetBool("isJumping", false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathBox"))
        {
            GameManager.Instance.GameOver();
            //Destroy(gameObject);
        }
    }
}
