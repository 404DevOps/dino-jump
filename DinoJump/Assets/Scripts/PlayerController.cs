using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;

    [SerializeField] private float force;
    [SerializeField] private float speed;
    [SerializeField] private float horizontalInput;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            isGrounded = false;
        }
        if (horizontalInput != 0f)
        {
            Move();
        }
        
    }

    void Jump()
    {
        playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    void Move()
    {
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Good"))
        {
            Debug.Log("Collision with Gameobject: " + collision.gameObject.name);
            isGrounded = true;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathBox"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
