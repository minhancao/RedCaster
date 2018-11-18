using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBarFill : MonoBehaviour {

    Vector3 localScale;

    public static float fillBarAmount;

    public static float barAmount;

	// Use this for initialization
	public void Start () {
        fillBarAmount = transform.localScale.x;
        barAmount = transform.localScale.x;
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x <= 0)
        {
            localScale.x = fillBarAmount;
            barAmount = fillBarAmount;
            transform.localScale = localScale;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            localScale.x -= 0.0015f;
            barAmount = localScale.x;
            transform.localScale = localScale;
        }
        if (Input.GetButtonUp("Spacebar") || transform.localScale.x <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public float returnFillBarAmount()
    {
        return fillBarAmount;
    }

    public float returnBarAmount()
    {
        return barAmount;
    }

    public void setBarAmountBack()
    {
        barAmount = fillBarAmount;
    }
}
