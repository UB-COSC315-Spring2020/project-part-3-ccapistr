using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathway : MonoBehaviour
{
    public float speed = 5;
    private float waitTime;
    public float startWaitTime = 2;

    public Transform[] moveSpots;
    public int location = 0;

    public int temp;

    public float movement;
    public GameObject player;

    public PlayerDetection detection;
    public bool playerDies;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(location >= moveSpots.Length)
        {
            location = 0;
        }
        temp = location;

        if (!(detection.detectedPlayer))
        {
            //if player is not seen, do these in order to move to predestined locationsv  
            movement = transform.position.x - moveSpots[location].position.x;
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[location].position, speed * Time.deltaTime);
        }
        if (detection.detectedPlayer)
        {
            movement = transform.position.x - player.transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (speed + 1) * Time.deltaTime);

            if (detection.collidedPlayer && playerDies == false)
            {
                Debug.Log("Player is caught and dies");
                player.GetComponent<movement>().enabled = false;
                this.gameObject.GetComponent<Pathway>().enabled = false;
                player.GetComponent<Health>().hasDied = true;

                playerDies = true;
            }
        }

        if(Vector2.Distance(transform.position, moveSpots[location].position) <= 0)
        {
            if(waitTime <= 0)
            {
                if(location < moveSpots.Length)
                {
                    location++;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
