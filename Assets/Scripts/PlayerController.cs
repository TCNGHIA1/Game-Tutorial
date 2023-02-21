using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;
    public float speed, height;
    bool grounded = false;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        GameController.instance.check(false);
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
        HandleMovement();
        if (grounded)
        {
            if(rBody.velocity.x == 0)
            {
                ani.SetBool("isRun", false);
                ani.SetBool("isJump", false);
            }
            else
            {
                ani.SetBool("isRun", true);
            }
        }
        else
        {
            ani.SetBool("isJump", true);
        }
    }
    
    private void Jump()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rBody.velocity = Vector2.up * height;
        }
    }
    
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.velocity = new Vector2(-speed, rBody.velocity.y);
            transform.localScale = new Vector3(-0.2f,transform.localScale.y,transform.localScale.z);   
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rBody.velocity = new Vector2(+speed, rBody.velocity.y);
                transform.localScale = new Vector3(0.2f, transform.localScale.y, transform.localScale.z);

            }
            else
            {
                rBody.velocity = new Vector2(0, rBody.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameController.instance.check(true);

            Time.timeScale = 0;
        }
    }
    //check player is standing on the ground
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        
    }

    //check player touch obstacle then game over
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameController.instance.check(true);
            Time.timeScale = 0;
        }
    }

    //check player isn't standing on the ground
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }


    }
}
