using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public bool isTalking;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talkToNPC()
    {
        if (!isTalking)
        {
            isTalking = true;
            Debug.Log("NPC is now talking");
        }

    }
}
