using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {
    public GameObject effect;

    public void play(Vector3 position, Quaternion rotation){
        Instantiate(effect, position, rotation);
    }


}
