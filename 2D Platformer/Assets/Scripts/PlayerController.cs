using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 move;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpSpeed = 3f;

    public Animator animator;

    [SerializeField]

    private int score;
    public Text scoreText;
    
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

        if(Input.GetKey("q"))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("deleted all!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            Debug.Log("+1 coin");
            score++;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
            CheckHighScore();
        }

        if(collision.tag == "noway")
        {
            //gameover
            Debug.Log("Game Over!");
            CheckHighScore();
        }
    }

    void CheckHighScore()
    {
        if(PlayerPrefs.GetInt("highscore") < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            Debug.Log("new record!");
        }
    }
}
