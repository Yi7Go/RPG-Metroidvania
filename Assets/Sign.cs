using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;


    private void Update()
    {
        if (isPlayerInSign)
        {
            dialogBox.SetActive(true);
            dialogBoxText.text = signText;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()!= null)
        //Debug.Log("���뷶Χ");
        isPlayerInSign = true;
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            //Debug.Log("�뿪��Χ");
        isPlayerInSign = false;
        dialogBox.SetActive(false);
    }

}
