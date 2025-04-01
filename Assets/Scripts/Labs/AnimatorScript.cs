using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public Animator animator;
    private float direction;
    public SpriteRenderer spriteRenderer;

    public bool isAttacking = false;

    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs (direction));

        if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }

        if (direction != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HeroKnight_Attack1"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    /*public void AttackHasFinnished()
    {
        animator.ResetTrigger("Attack");
    }*/
}
