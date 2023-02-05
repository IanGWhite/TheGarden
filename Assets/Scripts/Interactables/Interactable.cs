using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    [SerializeField] public bool proximityTrigger = false;
    public KeyCode interactKey; //keybind for interaction with object
    public UnityEvent interactAction;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            Debug.Log("In range triggered");
            if(Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }

            else if (proximityTrigger)
            {
                Debug.Log("Triggered");
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player now not in range");
        }
    }
}
