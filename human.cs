using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class human : MonoBehaviour {


    public float movingspeed;
	// Use this for initialization
	void Start () {

        movingspeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(movingspeed * Input.GetAxis("Vertical") * Time.deltaTime, 0f, -movingspeed * Input.GetAxis("Horizontal") * Time.deltaTime);
	}
}
