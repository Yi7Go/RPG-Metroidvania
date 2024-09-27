using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Thounder strike effect", menuName = "Data/Thounder strike")]

public class ThounderStrike_Effect : ItemEffect
{
    [SerializeField] private GameObject thounderStrikePrefab;

    public override void ExecuteEffect(Transform _enemyPosition)
    {
        GameObject newThounderStrike = Instantiate(thounderStrikePrefab,_enemyPosition.position,Quaternion.identity);

        Destroy(newThounderStrike,.5f);


    }

}
