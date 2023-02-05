using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator ani;
    Rigidbody2D rBody;
    float speed = 8f, height = 30f;
    float jumpTime, runTime;
    bool running, jumped, jumping, grounded = false;
    int moveState;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        State();
    }
    private void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.RightArrow) || !Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.Space))
        {
            moveState = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveState = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 2;
        }
        Jump();
    }
    void Move(Vector3 dir)
    {
        running = true;
        speed = Mathf.Clamp(speed, speed, 12f);
        runTime += Time.deltaTime;
        transform.Translate(dir * speed * Time.fixedDeltaTime);

        if (runTime < 3f && running)
        {
            speed += 0.5f;
        }
        else if (runTime > 3f)
        {
            speed = 14f;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, height);
            }
        }

        if (jumping && jumped)
        {
            rBody.gravityScale -= (0.1f * Time.fixedDeltaTime);
        }
        if (jumpTime > 0.5f)
        {
            jumping = false;
        }
        if (!jumping && jumped)
        {
            rBody.gravityScale += .4f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameController.instance.GameOver();
            Time.timeScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumped = false;
            jumping = false;

            ani.SetBool("isJump", false);
            jumpTime = 0;
            rBody.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameController.instance.GameOver();
            Time.timeScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    void State()
    {
        switch (moveState)
        {
            case 1:
                ani.SetBool("isRun", true);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

                Move(Vector3.right);
                break;
            case 2:
                ani.SetBool("isRun", true);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

                Move(Vector3.left);
                break;
            default:
                running = false;
                runTime = 0;
                speed = 10f;
                ani.SetBool("isRun", false);
                break;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jumped = true;
            jumping = true;
            jumpTime += Time.fixedDeltaTime;
            ani.SetBool("isJump", true);

        }
        else
        {
            jumping = false;
            ani.SetBool("isJump", false);
        }
    }
}
