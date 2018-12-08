using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    GameObject inventory;
	// Use this for initialization
	void Start () {
        inventory.SetActive(true);
        inventory.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Controls.player.inventory)){
            ToggleInventory();
        }

    }

    void ToggleInventory()
    {
        if (inventory != null)
        {
            if (!inventory.activeSelf)
            {
                inventory.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                inventory.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else
            Debug.Log("GameManager can't find inventory!");
    }
}
