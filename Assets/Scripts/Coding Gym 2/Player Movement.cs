using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRB;

    public float speed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRB.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
