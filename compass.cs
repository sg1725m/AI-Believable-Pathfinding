using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compass : MonoBehaviour {

    public Vector3 NorthDirection;
    public Transform Player;
    public Quaternion TargetDirection;

    public RectTransform Northlayer;
    public RectTransform TargetLayer;

    public Transform targetplace;


	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        ChangeNorthDirection();
        ChangeTargetDirection();
	}

    public void ChangeNorthDirection()
    {
        NorthDirection.z = Player.eulerAngles.y;
        Northlayer.localEulerAngles = NorthDirection;
    }

    public void ChangeTargetDirection()
    {
        Vector3 dir = transform.position - targetplace.position;

        TargetDirection = Quaternion.LookRotation(dir);

        TargetDirection.z = -TargetDirection.y;
        TargetDirection.x = 0;
        TargetDirection.y = 0;

        TargetLayer.localRotation = TargetDirection * Quaternion.Euler(NorthDirection);
    }
}
