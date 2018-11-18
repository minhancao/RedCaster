using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandRotation : MonoBehaviour {

    public CharacterController2D doesthiswork;

    public Transform refPoint;

    public int rotationOffset = 0;

    bool left = false;

    public static float rotZ;

	// Update is called once per frame
	void Update () {
        Vector3 difference;
        try
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize(); //normalizing the vector. meaning that all the sum of the vector will be equal to 1

            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //find the angle in degrees
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

            if((!Input.GetKey("d") && rotZ > 100 && rotZ < 179 && CharacterController2D.m_FacingRight) || (!Input.GetKey("d") && rotZ < -100 && rotZ > -180 && CharacterController2D.m_FacingRight))
            {
                left = true;
                doesthiswork.Flip();
            }

            if ((!Input.GetKey("a") && rotZ < 80 && rotZ > 0 && !CharacterController2D.m_FacingRight) || (!Input.GetKey("a") && rotZ < 0 && rotZ > -80 && !CharacterController2D.m_FacingRight))
            {
                left = false;
                doesthiswork.Flip();
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogException(e);
        }
    }

}
