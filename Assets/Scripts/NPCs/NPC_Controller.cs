using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private GameObject dialogue;

    private void Start()
    {
        Debug.Log("Activated");
        dialogue.SetActive(false);
    }

    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public bool DialogueActive()
    {
        return dialogue.activeInHierarchy;
    }
}
