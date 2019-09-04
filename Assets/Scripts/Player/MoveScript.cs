using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //float circle = Mathf.Sin(Time.time * 1) * -50;

        //transform.position += new Vector3(0, 0, 2 * Time.deltaTime * 2);
        transform.Rotate(Vector3.up * Time.deltaTime * 3);
    }
}
