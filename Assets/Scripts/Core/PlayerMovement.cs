using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D body;
    private NPC_Controller npc;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!inDialogue())
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


            //flips player
            if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(-0.2f, 0.2f, 0);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(0.2f, 0.2f, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                body.velocity = new Vector2(body.velocity.x, speed);
            }
        }
    }
    
    private Boolean inDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();

        else
            return false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("Player in range");
                npc.ActivateDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }


}
