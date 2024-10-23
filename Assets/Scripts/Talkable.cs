using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Talkable : MonoBehaviour
{


    public bool isEntered;
    [TextArea(1,3)]
    public string[] lines;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isEntered = false;
        }
    }


    private void Update()
    {
        if (isEntered && Input.GetKeyDown(KeyCode.E) && DialogueManager.instance.dialogueBox.activeInHierarchy == false )
        {
            DialogueManager.instance.ShowDialogue(lines);
        }

    }
}
