using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{

   [SerializeField] private Transform _player;
   [SerializeField] private float speed = 5;
    Vector3 currentposition;
    int direction;
    float timer;
    float changeTime;

    [SerializeField] private Vector3 angleToRotate;

    // Start is called before the first frame update
    void Start()
    {
        currentposition = transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        //Direction 0r Distance = Destination - Source 
        Vector3 distance = _player.transform.position - currentposition; //This is will give you the magnitude from the enemy to player.
        Debug.Log(distance.magnitude);
        distance.Normalize();
        //transform.eulerAngles = angleToRotate * Time.deltaTime * 10;
        transform.Translate(distance * Time.deltaTime * speed);

        if (transform.position.x < 0.1f)
        {
            speed = 0; //this will stop the enemy to move
            
        }



        /*
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        */

    }
}
