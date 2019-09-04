using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINCOS : MonoBehaviour
{ 
    [SerializeField] private float amplitude = 3;
    [SerializeField] private float frequency = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Cos(Time.time * frequency) * -amplitude;
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        float z = 0f;

        transform.position = new Vector3(x, y, z);
    }
}
