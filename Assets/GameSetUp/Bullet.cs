using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    public float Bulletforce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * Bulletforce);

        Destroy(this.gameObject, 2);
    }
}
