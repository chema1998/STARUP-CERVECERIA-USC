using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public String[] lines;
    public float textSpeed = 0.1f;
    int index;

    // Maximum number of characters per line
    public int maxCharsPerLine = 90;

    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        string currentLine = lines[index];
        string displayText = "";
        int charCount = 0;

        foreach (char letter in currentLine.ToCharArray())
        {
            displayText += letter;
            charCount++;
            
            // Check if we need to split the line
            if (charCount >= maxCharsPerLine && letter == ' ')
            {
                displayText += "\n";
                charCount = 0;
            }
            
            dialogueText.text = displayText;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Panel"))
        {
                  }
    }
}