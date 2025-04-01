using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [Header("Player Model")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] sprites;


    [Header("Player Movement")]
    [SerializeField]
    private float x;
    [SerializeField]
    private float y;

    [SerializeField]
    private float maxSpeed = 5;
    [SerializeField]
    private float rotSpeed = 1;

    [Header("Player Object")]
    [SerializeField]
    private Rigidbody2D playerRB;

    private float t = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player Input

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //Animation

        if (x > 0)
        {
            spriteRenderer.sprite = sprites[3];
        }
        else if (x < 0)
        {
            spriteRenderer.sprite = sprites[1];
        }

        else if (y > 0)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (y <= 0)
        {
            spriteRenderer.sprite = sprites[2];
        }

        //Player Movement

        if (x > 0)
        {
            playerRB.AddTorque(-rotSpeed);
        }
        else if (x < 0)
        {
            playerRB.AddTorque(rotSpeed);
        }

        if (y > 0)
        {
            playerRB.AddForce(transform.up, ForceMode2D.Force);
        }

        if (playerRB.velocity.magnitude > maxSpeed)
        {
            playerRB.velocity = playerRB.velocity.normalized * maxSpeed;
        }

        if (Input.GetButtonDown("Fire2"))
            t = 0;

        if (Input.GetButton("Fire2"))
        {
            t += 5 * Time.deltaTime;
            playerRB.velocity = new Vector2 (Mathf.Lerp(playerRB.velocity.x, 0, t), Mathf.Lerp(playerRB.velocity.y, 0, t));
        }
    }
}
