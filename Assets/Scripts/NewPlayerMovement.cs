using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movespeed;
    [SerializeField] private float _jumpspeed;
    private Vector3 _velocity;
    private Rigidbody rigidbody;
    private Vector3 _direction;
    [SerializeField] private float _roatationspeed;
    private int _jumpcount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        _direction = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {

    //https://www.noob-programmer.com/unity3d/basic-movement-in-unity3d/
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rigidbody.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * _movespeed);
        */

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * _roatationspeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * _movespeed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpcount++;
            if (_jumpcount <2)
            {
                rigidbody.AddForce(Vector3.up * _jumpspeed, ForceMode.Impulse);
            }
            else
            {
                _jumpcount = 0;
            }
           
        }

        /*
        _velocity = _direction * _movespeed;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rigidbody.MovePosition(_velocity * Time.deltaTime);
            rigidbody.velocity = _velocity;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //rigidbody.MovePosition(_velocity * Time.deltaTime);
            rigidbody.velocity = -_velocity;
        }
        */
    }
}
