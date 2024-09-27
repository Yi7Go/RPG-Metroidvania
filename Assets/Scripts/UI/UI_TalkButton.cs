using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TalkButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            talkUI.SetActive(true);
        }

    }
}
