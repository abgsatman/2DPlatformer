using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 move;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpSpeed = 3f;

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += move * speed * Time.deltaTime;
        animator.SetFloat("moveSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y, 0f))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
        else if(animator.GetBool("isJumping") &&  Mathf.Approximately(rb.velocity.y, 0))
        {
            animator.SetBool("isJumping", false);
        }

        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } 
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

    }
}
