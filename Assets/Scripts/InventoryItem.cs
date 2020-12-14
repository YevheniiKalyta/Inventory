using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item item;
    public Image image;
    public GameObject storedItem;

    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = item.sprite;
    }

    public void OnPointerEnter()
    {

        TutorialText.ChangeText("Click an Item to drop it");
        InfoUpdater.EnterAction(item);
    }

    public void OnPointerExit()
    {
        TutorialText.ChangeText("");
        InfoUpdater.EnterAction(null);
    }

    public void OnPointerClick()
    {
        InfoUpdater.EnterAction(null);
        storedItem.SetActive(true);
        storedItem.transform.position = PlayerInventoryManager.playerTransform.position;

        PlayerInventoryManager.onDropAction(this.item);
        Destroy(this.gameObject);
    }

    
}
