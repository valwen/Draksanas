using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVerification : MonoBehaviour {
    public float distance = 1f;
    public bool isGrounded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GroundCheck();
    }

    void GroundCheck()
    {
        RaycastHit hit;

        Vector3 dir = new Vector3(0, -1, 0);

        Debug.DrawRay(transform.position, dir * distance, Color.blue);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


}
