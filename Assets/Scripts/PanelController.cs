using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

    public GameObject Panel;

	// Use this for initialization
	void Start () {
        Panel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetButtonDown("Switch")
        if(Input.GetKeyDown(Controls.player.cast))
        {
            Panel.SetActive(true);
        }
        //if (Input.GetButtonUp("Switch"))
        if(Input.GetKeyUp(Controls.player.cast))
        {
            MouseMovement[] ms = FindObjectsOfType<MouseMovement>();
            foreach (MouseMovement mm in ms){
                mm.Deactivate();
            }
            Panel.SetActive(false);
        }
    }
}

