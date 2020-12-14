using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public string itemName;
    public int cost,itemID;
    public Sprite sprite;
    public float weight;


    public Item(string name, int cost, Sprite sprite,float weight,int id)
    {
        this.itemID = id;
        this.itemName = name;
        this.cost = cost;
        this.sprite = sprite;
        this.weight = weight;

    }
}
