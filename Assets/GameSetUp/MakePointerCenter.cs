using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePointerCenter : MonoBehaviour
{
    float xcen;
    float ycen;
    Vector2 setposition;

    // Start is called before the first frame update
    void Start()
    {
        xcen = (float)Screen.width / 2;
        ycen = (float)Screen.height / 2;
        Debug.Log(xcen + " " + ycen);


        setposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        setposition.x = transform.position.x;
        setposition.y = transform.position.y;

        transform.position = setposition;
    }
}
