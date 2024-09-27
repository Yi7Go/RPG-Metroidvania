using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private int possibleItemDrop;
    [SerializeField] private ItemData[] possibleDrop;
    [SerializeField] private List<ItemData> dropList= new List<ItemData>();//原本未实例化，不掉洛

    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private ItemData item;



    public virtual void GenerateDrop()//之前是怕public virtual void
    {
        for (int i = 0; i < possibleDrop.Length; i++)
        {
            if (Random.Range(0, 100) <= possibleDrop[i].dropChance)
                dropList.Add(possibleDrop[i]);
        }

        for (int i = 0; i < possibleItemDrop; i++)
        {
            ItemData randomItem = dropList[Random.Range(0, dropList.Count - 1)];

            dropList.Remove(randomItem);
            DropItem(randomItem);
        }

   
    }
    protected void DropItem(ItemData _itemData)
    {
        GameObject newDrop = Instantiate(dropPrefab, transform.position, Quaternion.identity);

        Vector2 randomVelocity = new Vector2(Random.Range(-5, 5), Random.Range(12, 15));

        newDrop.GetComponent<ItemObject>().SetupItem(_itemData, randomVelocity);
    }
}

