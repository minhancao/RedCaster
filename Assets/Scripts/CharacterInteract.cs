using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour {
    [SerializeField]
    private DialogueManager DM;

    public GameObject currentInteractableObject = null;
    public Interactable currentInteractableObjectScript = null;

    public bool DEBUG = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Controls.player.interact ) && currentInteractableObject) {
            if (currentInteractableObjectScript.type == Interactable.interType.NPC){
                if (currentInteractableObjectScript.Triggered){
                    DM.DisplayNextSentence();
                }
                else{
                    currentInteractableObjectScript.TriggerDialogue();
                }
            }
            if (currentInteractableObjectScript.type == Interactable.interType.Item){
                Debug.Log("Interacting with Item");
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable")){
            currentInteractableObject = collision.gameObject;
            currentInteractableObjectScript = collision.gameObject.GetComponent<Interactable>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentInteractableObject = null;
        currentInteractableObjectScript = null;
    }
}
