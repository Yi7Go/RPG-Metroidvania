using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;

    public string id;
    public bool activationStatus;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    [ContextMenu("Generate checkpoint id")]
    private void Start()
    {        
    }



    private void GenerateId()
    {
        id = System.Guid.NewGuid().ToString();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            ActivateCheckpoint();
        }
    }

    public void ActivateCheckpoint()
    {
        //if (activationStatus == false) 
        AudioManager.instance.PlaySFX(5,transform);
        activationStatus = true;
        anim.SetBool("active", true);
        Debug.Log("checkpoint active");

    }
}
