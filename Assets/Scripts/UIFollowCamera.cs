using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{

   

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera camera = Camera.main;
        //transform.LookAt(camera.transform);
        //transform.LookAt(camera.transform, camera.transform.rotation * Vector3.up);
        //transform.rotation = Quaternion.Euler(0, camera.transform.localEulerAngles.y, 0);
        //Debug.Log("LookAT");

        float pingPongX = Mathf.Cos(Time.time * 2 * .5f) * -2;
        float pingPongY = Mathf.Sin(Time.time * 2 * .5f) * 2;
        transform.position = new Vector3(0, pingPongY, 0);
       
    }





}
