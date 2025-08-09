using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb;

    public float speed;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.Instance.isTalking == false)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if(horizontal > 0)
            {
                animator.SetBool("Kanan", true);
                animator.SetBool("Atas", false);
                animator.SetBool("Kiri", false);
                animator.SetBool("Bawah", false);
                animator.SetBool("Idle", false);
            }
            else if(horizontal < 0)
            {
                animator.SetBool("Kanan", false);
                animator.SetBool("Atas", false);
                animator.SetBool("Kiri", true);
                animator.SetBool("Bawah", false);
                animator.SetBool("Idle", false);
            }
            else if(vertical > 0)
            {
                animator.SetBool("Kanan", false);
                animator.SetBool("Atas", true);
                animator.SetBool("Kiri", false);
                animator.SetBool("Bawah", false);
                animator.SetBool("Idle", false);
            }
            else if(vertical < 0)
            {
                animator.SetBool("Kanan", false);
                animator.SetBool("Atas", false);
                animator.SetBool("Kiri", false);
                animator.SetBool("Bawah", true);
                animator.SetBool("Idle", false);
            }
            else
            {
                animator.SetBool("Kanan", false);
                animator.SetBool("Atas", false);
                animator.SetBool("Kiri", false);
                animator.SetBool("Bawah", false);
                animator.SetBool("Idle", true);
            }

            movement = new Vector2(horizontal, vertical);
        }
        else
        {
            animator.SetBool("Kanan", false);
            animator.SetBool("Atas", false);
            animator.SetBool("Kiri", false);
            animator.SetBool("Bawah", false);
            animator.SetBool("Idle", true);
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }
}
