using UnityEngine;

public class Destroy : MonoBehaviour {
    public float Seconds;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, Seconds);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
