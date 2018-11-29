using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public enum interType {Item, NPC};
    public interType type;

    public Dialogue dialogue;
    // public Description description;

    public bool Triggered = false;

    public void TriggerDialogue () {
        Triggered = true;

        // SHOULD REPLACE WITH DIALOGUE MANAGER SINGLETON
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
