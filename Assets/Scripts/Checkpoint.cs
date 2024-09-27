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
    private void Start()
    {        
    }


    [ContextMenu("Generate checkpoint id")]

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
        if (activationStatus == false) 
        AudioManager.instance.PlaySFX(5,transform);
        anim.SetBool("active", true);
        activationStatus = true;
    }
}
