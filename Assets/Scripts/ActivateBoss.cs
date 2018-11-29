using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour {

    public GameObject BOSS;

    private void Start()
    {
        BOSS.SetActive(false);
    }
    void OnTriggerEnter2D() {
        BOSS.SetActive(true);
    }
}
