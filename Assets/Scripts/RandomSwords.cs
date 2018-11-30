using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSwords : MonoBehaviour {

    public Sprite[] swords;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void castSword()
    {
        int random = Random.Range(0, 46);
    }
}
