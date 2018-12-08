using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour {

    public bool DEBUG;
    public Transform content;
    private Event keyEvent;
    private Text buttonText;
    private KeyCode newKey;

    bool waitingForKey;


	// Use this for initialization
	void Start () {
        waitingForKey = false;

        for (int i = 0; i < content.childCount; i++) {
            if (content.GetChild(i).name == "LeftKey"){
                content.GetChild(i).GetComponentInChildren<Text>().text = Controls.player.left.ToString();
            }
            if (content.GetChild(i).name == "RightKey")
            {
                content.GetChild(i).GetComponentInChildren<Text>().text = Controls.player.right.ToString();
            }
            if (content.GetChild(i).name == "JumpKey")
            {
                content.GetChild(i).GetComponentInChildren<Text>().text = Controls.player.jump.ToString();
            }
            if (content.GetChild(i).name == "CastKey")
            {
                content.GetChild(i).GetComponentInChildren<Text>().text = Controls.player.cast.ToString();
            }
            if (content.GetChild(i).name == "ShieldKey")
            {
                content.GetChild(i).GetComponentInChildren<Text>().text = Controls.player.shield.ToString();
            }
            if (content.GetChild(i).name == "InventoryKey")
            {
                content.GetChild(i).GetComponentInChildren<Text>().text = Controls.player.inventory.ToString();
            }

        }
    }
	
    private void OnGUI()
    {
        keyEvent = Event.current;

        if (keyEvent.isKey && waitingForKey){
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment (string keyName) {
        if (!waitingForKey){
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void sendText(Text text) {
        buttonText = text;
    }

    private IEnumerator WaitForKey() {
        if (DEBUG) Debug.Log("Wait for key called");
        while (!keyEvent.isKey)
            yield return null;
    }

    private IEnumerator AssignKey(string keyName){
        waitingForKey = true;
        yield return WaitForKey();

        switch (keyName) 
        {
            case "left":
                Controls.player.left = newKey;
                buttonText.text = Controls.player.left.ToString();
                PlayerPrefs.SetString("leftKey", Controls.player.left.ToString());
                break;
            case "right":
                Controls.player.right = newKey;
                buttonText.text = Controls.player.right.ToString();
                PlayerPrefs.SetString("rightKey", Controls.player.right.ToString());
                break;
            case "jump":
                Controls.player.jump = newKey;
                buttonText.text = Controls.player.jump.ToString();
                PlayerPrefs.SetString("jumpKey", Controls.player.jump.ToString());
                break;
            case "cast":
                Controls.player.cast = newKey;
                buttonText.text = Controls.player.cast.ToString();
                PlayerPrefs.SetString("castKey", Controls.player.cast.ToString());
                break;
            case "shield":
                Controls.player.shield = newKey;
                buttonText.text = Controls.player.shield.ToString();
                PlayerPrefs.SetString("shieldKey", Controls.player.shield.ToString());
                break;
            case "inventory":
                Controls.player.inventory = newKey;
                buttonText.text = Controls.player.inventory.ToString();
                PlayerPrefs.SetString("inventoryKey", Controls.player.inventory.ToString());
                break;
        }

    }
}
