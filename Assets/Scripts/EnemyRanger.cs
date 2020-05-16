using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanger : MonoBehaviour
{
    public PlayerDetection playerdetection;
    public Pathway pathway;
    public GameObject arrowPrefab;
    public Transform firePoint;

    private float attackCooldown;
    public float startAttackCooldown = 3;
    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = startAttackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdetection.detectedPlayer)
        {
            pathway.enabled = false;
            if(attackCooldown <= 0)
            {
                Shoot();
                attackCooldown = startAttackCooldown; //resets the cooldown attack
            }
            else
            {
                attackCooldown -= Time.deltaTime;
            }
        }
        if (!(playerdetection.detectedPlayer))
        {
            pathway.enabled = true;
        }
    }
    private void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }

}
