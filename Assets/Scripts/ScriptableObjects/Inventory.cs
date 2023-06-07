using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int coins;
    public float maxMagic = 10;
    public float currentMagic;
    
    public void  OnEnable(){
        currentMagic = maxMagic;

    }

    public void ReduceMagic(float magicCost){
        currentMagic -=magicCost;
    }
    public bool CheckForItem(Item item){
        if (items.Contains(item)){
            return true;
        }
        return false;
    }

    public void AddItem(Item itemtoAdd)
    {
        if(itemtoAdd.isKey){
            numberOfKeys++;
        }
        else{
            if (!items.Contains(itemtoAdd)){
                items.Add(itemtoAdd);
            }
        }
    }
}
