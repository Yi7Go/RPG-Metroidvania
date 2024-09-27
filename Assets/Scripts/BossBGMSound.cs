using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBGMSound : MonoBehaviour
{
    [SerializeField] private int bossSoundIndex;
    [SerializeField] private AudioSource[] bgm;

    public void StopAllBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Player>() != null)
            AudioManager.instance.PlayBGM(bossSoundIndex);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            AudioManager.instance.StopAllBGM();
    }
}
