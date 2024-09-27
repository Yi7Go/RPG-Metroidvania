using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour,ISaveManager
{
    public static GameManager instance;
    [SerializeField] private Checkpoint[] checkpoints;

    [Header("Lost currency")]
    [SerializeField] private GameObject lostCurrencyPrefab;
    public int lostCurrencyAmount;
    [SerializeField] private float lostCurrencyX;
    [SerializeField] private float lostCurrencyY;
    public void Awake()
    {


        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;

    }

    public void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>(true);
        
    }

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    public void LoadData(GameData _data)
    {

        foreach (KeyValuePair<string,bool> pair in _data.checkpoints)
        {
            foreach (Checkpoint checkpoint in checkpoints)
            {
                if(checkpoint.id == pair.Key && pair.Value ==true)
                    checkpoint.ActivateCheckpoint();
            }
        }
    }

    public void SaveData(ref GameData _data)
    {

        _data.checkpoints.Clear();

        foreach (Checkpoint checkpoint in checkpoints)
        {
            _data.checkpoints.Add(checkpoint.id, checkpoint.activationStatus);
        }
    }
    public void PauseGame(bool _pause)
    {
        if(_pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
                        

}
