using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    private Rigidbody2D rBody;
    private float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        speed = 85f;
        maxDistance =20f;
        distance = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance += Time.fixedDeltaTime * 2.5f;
        if(distance > maxDistance)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            distance = 0;
        }
        rBody.velocity = new Vector2(-transform.localScale.x, 0) * speed;
    }
}
