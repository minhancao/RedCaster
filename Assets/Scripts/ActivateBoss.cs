using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour {

    public GameObject BOSS;
    public Camera camera;
    public GameObject character;
    AudioSource audio1;
    AudioSource audio2;

    private void Start()
    {
        audio1 = camera.GetComponent<AudioSource>();
        audio2 = character.GetComponent<AudioSource>();
        BOSS.SetActive(false);
    }

    void OnTriggerEnter2D() {
        BOSS.SetActive(true);
        Debug.Log(audio1);
        Debug.Log(audio2);
        audio1.Stop();
        audio2.Play();
        Destroy(gameObject);
    }
}
