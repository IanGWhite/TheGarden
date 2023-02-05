using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header ("Text Properties")]
        [SerializeField] private string input;
        //[SerializeField] private Color color;
       // [SerializeField] private Font font;

        [Header("Time")]
        [SerializeField] private float delay;

        [Header("Character Sprite")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;

        private IEnumerator lineAppear;

        private void Awake()
        {
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;

        }

        private void OnEnable()
        {
            ResetLine();
            lineAppear = WriteText(input, textHolder, delay);
            StartCoroutine(lineAppear);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textHolder.text != input)
                {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;
                }
                else
                    finished = true;
            }
        }

        private void ResetLine()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            finished = false;
        }
    }
}

