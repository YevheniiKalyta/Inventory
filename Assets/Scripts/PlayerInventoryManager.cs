using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryManager : MonoBehaviour
{
    public static List<Item> items;
    public float actualWeight;
    public float maxWeight;
    public GameObject itemPrefab;
    public GameObject UIParent;
    public Text actualWeightText;
    public static Transform playerTransform;
    public float speed=4;

    public static Action<Item> onDropAction;

    void Start()
    {
        UpdateUI();
        items = new List<Item>();

        playerTransform = gameObject.transform;
        onDropAction = OnDrop;
    }


    private void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * speed;
    }
    public void OnPickup(GameObject go,Item item)
    {
        if (actualWeight + item.weight < maxWeight)
        {
            items.Add(item);
            actualWeight += item.weight;
            GameObject temp = Instantiate(itemPrefab, UIParent.transform);
            temp.GetComponent<InventoryItem>().item = item;
            temp.GetComponent<InventoryItem>().storedItem = go;
            UpdateUI();
            go.SetActive(false);
        }
    }

    public void OnDrop(Item item)
    {
        actualWeight -= item.weight;
        items.Remove(item);
        UpdateUI();
    }

    void UpdateUI()
    {
        actualWeightText.text = actualWeight.ToString();
    }
}
