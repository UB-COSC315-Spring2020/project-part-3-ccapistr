using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 10;
    public float jumpForce = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(xMovement, yMovement);
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump(Vector2.up);
        }

    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hazard")
        {
            this.GetComponent<movement>().enabled = false;
            Debug.Log("player has collided with a hazard");
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}