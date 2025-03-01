using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float sensitivity = 9.0f;
    public float yAngle = 0;
    public float xAngle = 0;
    public float yAngleVariation = 45f; 
    public float xAngleVariation = 45f;

    void Update()
    {
        xAngle = Mathf.Clamp(xAngle - Input.GetAxis("Mouse Y") * sensitivity,-xAngleVariation,xAngleVariation);
        yAngle = Mathf.Clamp(yAngle + Input.GetAxis("Mouse X") * sensitivity,-yAngleVariation,yAngleVariation);
        transform.localEulerAngles = new Vector3(xAngle, yAngle, 0);
    }
}
	
	void Start () 
	{ 
		// Make the rigid body not change rotation 
		if (GetComponent<Rigidbody>()) 
			GetComponent<Rigidbody>().freezeRotation = true; 
	} 
}