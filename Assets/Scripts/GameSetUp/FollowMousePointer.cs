using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://wiki.unity3d.com/index.php/TextureScale

public class FollowMousePointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject bulletPrefab;
    public GameObject bullerEmitterObj;
    public float bulletforce = 20.0f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public Vector2 hitlocation;
    GameObject bullet;


    //Touch
    Vector2 startpos;
    Vector2 endpos;

    void Update()
    {
        #if UNITY_EDITOR
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        //Restrict X-Axis rotation 
        var floatx = Mathf.Clamp(pitch, -90f, 90);

        transform.eulerAngles = new Vector3(floatx, yaw, 0.0f);

        Vector3 setposition = transform.position;

        setposition.x = this.transform.position.x;
        setposition.z = this.transform.position.z;
        setposition.y = 5f;

        transform.position = setposition;



        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * 15);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 15);
        }

        //Vector3 objectPos = transform.GetChild(1).position;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hitinfo))
            {
            //Debug.Log(hitinfo.collider.name);
            hitlocation = hitinfo.point;
            bullet = Instantiate(bulletPrefab, bullerEmitterObj.transform.position, bullerEmitterObj.transform.rotation) as GameObject;
            //bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletforce);
            //bullet.transform.Translate(Vector3.forward * bulletforce * Time.deltaTime);
           
            }
        }



#endif


#if UNITY_ANDROID
        /*------------------------Touch Inputs----------------------------*/

        if (Input.touchCount > 0)
        {


            Touch touch = Input.GetTouch(0);

            if (Input.touches.Length > 0)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    startpos = touch.position;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    endpos = touch.position;
                    if (endpos.x > 1f)
                    {
                        transform.position += transform.position * Time.deltaTime * 5f;

                    }


                    Debug.Log("endpos: " + endpos);
                }

                if (touch.phase == TouchPhase.Stationary)
                {
                    if (startpos.y > 0.5f)
                    {
                        transform.Translate(Vector3.forward * Time.deltaTime * 5, Space.World);
                        Debug.Log("Stationary");
                    }
                    else if (endpos.y < -0.5f)
                    {
                        transform.Translate(Vector3.back * Time.deltaTime * 5, Space.World);
                    }
                }

            }
        }

        /*-------------------------------------------------------------------*/
        #endif

    


        }


}

