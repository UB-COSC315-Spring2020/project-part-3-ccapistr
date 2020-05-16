using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public LayerMask player;
    public Pathway pathway;

    public bool detectedPlayer;
    public bool collidedPlayer;

    public float angle = 0.25f;
    public float direction;
    public Vector2 playerDetection;
    public Vector2 collideDetection;
    public Vector2 size;
    public float startWaitTime = 2;
    private float waitTime;

    public bool facing_Right = true;

    private Color debugColor = Color.cyan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectedPlayer = Physics2D.OverlapBox((Vector2)transform.position + playerDetection, size, angle, player);
        collidedPlayer = Physics2D.OverlapBox((Vector2)transform.position + collideDetection, size/3, angle, player);

        //if player is not found
        FacingDirection();
        if((direction == 1 && !facing_Right))
        {
            Flip();
            //Debug.Log("looking left" + direction + " " + facing_Right);
        }
        else if(direction == -1 && facing_Right)
        {
            Flip();
            //Debug.Log("Looking right" + direction + " " + facing_Right);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        var position = new Vector2[] { playerDetection, collideDetection };

        Gizmos.DrawWireCube((Vector2)transform.position + playerDetection, size);
        Gizmos.DrawWireCube((Vector2)transform.position + collideDetection, size/3);
    }

    private void FacingDirection()
    {
        if(pathway.movement > 0.3f)
        {
            direction = 1;
        }
        else if(pathway.movement < -0.3f)
        {
            direction = -1;
        }
    }

    private void Flip()
    {
        playerDetection *= -1;
        facing_Right = !facing_Right;
    }
}
