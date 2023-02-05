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
    private bool isRight = false;
    private bool isRun = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRun = true;
            body.velocity = new Vector2(horizontalInput * (speed + (speed / 2)), body.velocity.y);
        }
        else {
            isRun = false;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

        //flips player
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(-24.4f, 24.4f, 0);
            isRight = false;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(24.4f, 24.4f, 0);
            isRight = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, (speed+speed+speed));
        }
               
        anim.SetBool("run", horizontalInput != 0);

        if (isRight)
            anim.SetBool("isRight", horizontalInput != 0);

        if(isRun)
            anim.SetBool("isRun", horizontalInput != 0);
    }

/*    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("Interacted");
            npc = collision.gameObject.GetComponent<NPC_Controller>();

            if (Input.GetKey(KeyCode.E))
                npc.ActivateDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }*/

}