using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObjects : MonoBehaviour
{
    public GameObject destoryFX;

    public void DestoryObject()
    {
        if (destoryFX != null)
        {
            Instantiate(destoryFX, transform.position, transform.rotation);
        }



        Destroy(gameObject);
    }




}
