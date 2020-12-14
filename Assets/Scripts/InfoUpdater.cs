using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoUpdater : MonoBehaviour
{
    public Item item;
    public Text itemName, cost, weight;
    public static Action<Item> EnterAction;

    private void OnEnable()
    {
        UpdateInfo(item);
        EnterAction += UpdateInfo;
    }


    public void UpdateInfo(Item item)
    {
        if (item != null)
        {
            itemName.text = item.itemName;
            cost.text = item.cost.ToString();
            weight.text = item.weight.ToString();
        }
        else
        {
            itemName.text = "";
            cost.text = "";
            weight.text = "";
        }
    }

    public void OnDisable()
    {
        EnterAction -= UpdateInfo;
    }
}
