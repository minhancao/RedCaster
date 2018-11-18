using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    public GameObject mouseEffect;
    public GameObject effect = null;
    public bool mouseDown = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0)){
            mouseDown = false;
            DestroyEffect();
        }
        if (effect != null){
            effect.transform.position = this.transform.position;
        }
    }

    void OnMouseOver()
    {
        if (effect == null){
            effect = Instantiate(mouseEffect, transform.position, transform.rotation);
        }
    }

    void OnMouseExit()
    {
        if (!mouseDown){
            DestroyEffect();
        }
    }

    public void DestroyEffect(){
        Destroy(effect);
    }

    public bool HasEffect(){
        return effect != null;
    }

    public void Deactivate(){
        mouseDown = false;
        Destroy(effect);
    }
}
