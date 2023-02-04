using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float damage;
    private Rigidbody2D body;
    private bool inRange = false;
    private float cooldownTimer= Mathf.Infinity;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    
    


    private void OnTriggerEnter2D(Collider2D Player)
    {
        inRange = true;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
            
            
        
            //will attack
            if (cooldownTimer >= attackCooldown && inRange == true)
            {
            Debug.Log("I'm Attacking");
            inRange = false;
            }
        

    }
}
