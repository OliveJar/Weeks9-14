using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRB;

    public float speed = 5f;
    public float jumpForce = 10f;

    public AnimatorScript animatorScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animatorScript.isAttacking)
        {
            playerRB.velocity = Vector2.zero;
        }
        else
            playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }*/
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }*/
}
