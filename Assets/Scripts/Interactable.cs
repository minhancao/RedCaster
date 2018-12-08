using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public enum interType {Item, NPC};
    public interType type;

    public Item item;
    public Dialogue dialogue;
    // public Description description;

    public bool Triggered = false;

    public void TriggerDialogue () {
        Triggered = true;

        // SHOULD REPLACE WITH DIALOGUE MANAGER SINGLETON
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void Interact(){
        PickUp();
        //Inspect();
    }
    void PickUp() {
        Debug.Log("picking up " + item.name);
        bool pickedUp = Inventory.instance.Add(item);
        if (pickedUp)
        {
            Destroy(gameObject);
            Debug.Log("item added!");
        }
        else
            Debug.Log("Inventory is full!");
    }


}
