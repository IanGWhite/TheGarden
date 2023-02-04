using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    private Transform currentCheckpoint;
   // private Health playerHealth;

   private void Awake()
    {
       // playerHealth = getComponent<Health>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
       // playerHealth.Respawn();

        //move camera to checkpoint room!!
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            //collision.GetComponent<Collider2D>().enabled;
            //collision.GetComponent<Animator>().SetTrigger("appear") //animation of save point
        }
    }
}
