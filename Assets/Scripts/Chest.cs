using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject Inventory;
    private bool canOpen;
    private bool isOpened;
    private Animator anim;

    private void Awake()
    {
    }

    private void Start()
    {
        
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.E))
       if (canOpen && !isOpened)
       {
           anim.SetTrigger("Opening");
           isOpened = true;
           Instantiate(Inventory,transform.position,Quaternion.identity);

        }

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Player>() != null)
        {
            canOpen = true;
        }


        //if (collision.GetComponent<Player>() != null)
        //{
        //    Debug.Log("ÔÚ¸½½ü");
        //    canOpen = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            canOpen = false;
        }
    }


}
