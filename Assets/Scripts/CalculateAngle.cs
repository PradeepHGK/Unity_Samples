using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateAngle : MonoBehaviour
{

    [SerializeField] private Transform _enemy;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Calculate the direction by direction = destination - source
        //direction = _enemy.position - this.transform.position;

        //To follow mouse pointer 
        direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10) - transform.position);

        Debug.DrawLine(transform.position, direction, Color.blue);

        // CalculateAngle by using inverse tangent method "Atan2(-ve value)"
        //Atan2 returns angle in radian using rad2deg convert that to degree
        //In unity unit circle 180----0---90
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Debug.Log("Angle:_ " + angle);

        //Rotating object by angle in Quterinion angleaxis
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);

        //slerp 
        //transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, 100f * Time.deltaTime);

        //Using Eulerangles to rotate the object
        transform.eulerAngles = Vector3.forward * angle;

        
    }
}
