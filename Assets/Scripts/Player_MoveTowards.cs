using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player_MoveTowards : MonoBehaviour
{
    GameObject pole;
    [Header("Steering_Wheel")]
    public GameObject steeringWheel;
    //public GameObject frontTyreR;
    //public GameObject frontTyreL

    private WheelCollider _frontWheelR;
    private WheelCollider _frontWheelL;
    private WheelCollider _leftWheelR;
    private WheelCollider _leftWheelL;

    private Transform _frontWheelR_T;
    private Transform _frontWheelL_T;
    private Transform _leftWheelR_T;
    private Transform _leftWheelL_T;



    // Start is called before the first frame update
    void Start()
    {
        pole = GameObject.Find("Pole");

        
        
    }



    private void UpdateWheelPose()
    {

    }


    private void UpdateWheelPose(WheelCollider _wheelCollider, Transform _transform)
    {

    }

    // Update is called once per frame
    void Update()
    {

        //transform.position  = Vector3.MoveTowards(transform.position, pole.transform.position, 3.0f * Time.deltaTime);

        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * 2f;
        print(horizontal);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //steeringWheel.transform.localPosition += new Vector3(transform.rotation.x, -transform.rotation.y * horizontal * Time.deltaTime, transform.rotation.z);
            steeringWheel.transform.rotation = Quaternion.Euler(0f, steeringWheel.transform.rotation.y * horizontal, 0);
            this.transform.rotation = Quaternion.Euler(-90f, 0, steeringWheel.transform.rotation.y);
        }

        
        //transform.rotation = Quaternion.Slerp(steeringWheel.transform.rotation, this.transform.rotation, 2 * Time.deltaTime);
       

    }
}
