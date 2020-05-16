using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player collided with hazardous object");
            Debug.Log("Player is dead and cannot move");
            collision.GetComponent<movement>().enabled = false;
            collision.GetComponent<Health>().hasDied = true;
        }
    }
}
