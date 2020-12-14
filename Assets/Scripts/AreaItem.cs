using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaItem : MonoBehaviour
{
    public Item item;


    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            TutorialText.ChangeText("Press E to pick up Item");
            if (Input.GetKey(KeyCode.E))
            {
           

                other.gameObject.GetComponent<PlayerInventoryManager>().OnPickup(this.gameObject, this.item);

            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            TutorialText.ChangeText("");
    }

}
