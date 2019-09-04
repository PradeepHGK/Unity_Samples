using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerController : MonoBehaviour, IPlayerActions
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpspeed;

    Rigidbody rb;
    CharacterController _characterController;
    Vector3 _direction = Vector3.forward;
    [SerializeField]
    Vector3 velocity;

    [SerializeField]
    private float _gravity = 1.0f;

    public void Jump()
    {
        //transform.Translate(Vector3.up * Time.deltaTime * _jumpspeed);
        velocity.y = _jumpspeed;
 
    }

    public void MoveBackward()
    {
        _characterController.Move(-velocity * Time.deltaTime);
    }

    public void MoveForward()
    {
        //rb.MovePosition(_     direction * Time.deltaTime);
        //_characterController.SimpleMove(direction * Time.deltaTime * _speed
        _characterController.Move(velocity * Time.deltaTime);

    }

    public void RotateLeft()
    {
        transform.eulerAngles -= Vector3.up * Time.deltaTime * _speed;
        //Camera.main.transform.eulerAngles -= Vector3.up * Time.deltaTime * _speed;
    }

    public void RotateRight()
    {
        transform.eulerAngles += Vector3.up * Time.deltaTime * _speed;
        //Camera.main.transform.eulerAngles += Vector3.up * Time.deltaTime * _speed;
    }


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        velocity = _direction * _speed;
        print(velocity);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveBackward();
        }
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateRight();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateLeft();
        }

    


        if (_characterController.isGrounded == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = _jumpspeed;

            }


        }
        else
        {
            //velocity.y -= _gravity;
            print("isnotgrounded");
        }

    }
}
