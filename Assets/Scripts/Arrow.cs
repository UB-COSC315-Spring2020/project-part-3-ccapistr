using System.Collections;
using UnityEngine;


/**
 *Major Problem: Upon the assigned object's initial x-coordinate passing through the target's x-coordinate,
 * the object continues to fire forward away from the target.
 * 
 * Possible solution: Assign a face variable where upon going past through the target, multiply the push of the
 * object within the z or x coordinate by -1
 */
public class Arrow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float initialAngle;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        //change it to Rigidbody2D and replace components into 2D
        var rigid = GetComponent<Rigidbody2D>();

        Vector3 p = target.position;

        float gravity = Physics.gravity.magnitude;
        // Selected angle in radians
        float angle = initialAngle * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(p.x, 0, p.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);

        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = transform.position.y - p.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion) * (p.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        // Fire!
        rigid.velocity = finalVelocity;

        // Alternative way:
        // rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<movement>().enabled = false;
            target.GetComponent<Health>().hasDied = true;
        }
        Debug.Log(collision.name);
        if(collision.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

}