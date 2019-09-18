using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensorpathfinding : MonoBehaviour {


    public float maxDistance = 10;
    public LayerMask activeLayr;
    public float speed = 2f;
    private float directionValue = 2f;
    private float oppositedirectionValue = 2f;
    private float lifetime = 3.0f;

    private void Update()
    {
        transform.position += transform.forward * (speed * directionValue) * Time.deltaTime; //move 
        transform.position += transform.right * (speed * directionValue) * Time.deltaTime; //move 
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.left);
        Ray aay = new Ray(transform.position, Vector3.right);
        Ray say = new Ray(transform.position, Vector3.forward);
        Ray day = new Ray(transform.position, Vector3.back);

        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, activeLayr);
        RaycastHit[] bits = Physics.RaycastAll(aay, maxDistance, activeLayr);
        RaycastHit[] dits = Physics.RaycastAll(say, maxDistance, activeLayr);
        RaycastHit[] rits = Physics.RaycastAll(day, maxDistance, activeLayr);



        Debug.DrawLine(transform.position, transform.position + Vector3.left * maxDistance, Color.green);
        Debug.DrawLine(transform.position, transform.position + Vector3.right * maxDistance, Color.black);
        Debug.DrawLine(transform.position, transform.position + Vector3.forward * maxDistance, Color.cyan);
        Debug.DrawLine(transform.position, transform.position + Vector3.back * maxDistance, Color.red);


        foreach (RaycastHit hit in hits)
        {
            Debug.DrawLine(hit.point, hit.point + Vector3.up * 8, Color.green);

            transform.position += transform.forward * -2 * (speed * directionValue) * Time.deltaTime; // making the agent move based on the hit

        }

        foreach (RaycastHit hit in bits)
        {
            Debug.DrawLine(hit.point, hit.point + Vector3.up * 8, Color.black);
            transform.position += transform.forward * -2 * (speed * directionValue) * Time.deltaTime; // making the agent move based on the hit


             if (hit.transform.gameObject.tag == ("Obstacle"))
             {
                transform.position += transform.forward * 6 * (speed * oppositedirectionValue) * Time.deltaTime;

            }

              if (hit.transform.gameObject.tag == ("newpath"))
             {
                transform.position += transform.right * 1 * (speed * oppositedirectionValue) * Time.deltaTime;
            }
           
        }
        foreach (RaycastHit hit in dits)
        {
            Debug.DrawLine(hit.point, hit.point + Vector3.up * 8, Color.cyan);
            // Destroy(hit.transform.gameObject);

            transform.position += transform.right * -2 * (speed * oppositedirectionValue) * Time.deltaTime;
            transform.position += transform.forward * -4 * (speed * oppositedirectionValue) * Time.deltaTime;


             if (hit.transform.gameObject.tag == ("Obstacle"))
            {
                transform.position += transform.forward * -2 * (speed * oppositedirectionValue) * Time.deltaTime;
            }



        }
        foreach (RaycastHit hit in rits)
        {
            Debug.DrawLine(hit.point, hit.point + Vector3.up * 8, Color.red);

            // transform.position += transform.right *-2 *  (speed * oppositedirectionValue) * Time.deltaTime;

        }

    }


}
