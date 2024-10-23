using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText, nameText;

    [TextArea(1, 3)]
    public string[] dialogueLines;
    [SerializeField] private int currentLine;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }

        }



    }
    private void Start()
    {
        dialogueText.text = dialogueLines[currentLine];
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (dialogueBox.activeInHierarchy)
            {
                currentLine++;

                if (currentLine < dialogueLines.Length)
                {
                    CheckName();

                    dialogueText.text = dialogueLines[currentLine];
                }

                else
                {

                    dialogueBox.SetActive(false);
                }
            }
           
        }
    }

    public void ShowDialogue(string[] _newLines)
    {
        dialogueLines = _newLines;
        currentLine = 0;

        CheckName();

        dialogueText.text = dialogueLines[currentLine];
        dialogueBox.SetActive(true);

        //FindObjectOfType<Player>().isBusy =;

       
    }


    private void CheckName()
    {
        if (dialogueLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogueLines[currentLine].Replace("n-", "");
            currentLine++;
        }

    }
}
