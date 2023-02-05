using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D body;
    private NPC_Controller npc;
    private Animator anim;
    private bool inDialogue;
    private bool isRight;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!inDialogue)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


            //flips player
            if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(-80.2f, 80.2f, 0);
                isRight = true;
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(80.2f, 80.2f, 0);
                isRight = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                body.velocity = new Vector2(body.velocity.x * 2, 40);
            }
               
            anim.SetBool("run", horizontalInput != 0);

            if (isRight)
                anim.SetBool("isRight", horizontalInput != 0);
        }
    }

    private bool InDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();

        else
            return false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();
            if (Input.GetKey(KeyCode.E))
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