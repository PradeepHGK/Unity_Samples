using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeMenu : MonoBehaviour
{

    public Texture2D cursorPoint;

    float pitch, yaw;
   
    private void Start()
    {
        SetCursor();
    }

    void Update()
    {
        Swipe();

    }

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    [SerializeField] private float rotationSpeed;


    Vector2 cursorHotspot = new Vector2(5f, 5f);
    void SetCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(cursorPoint, cursorHotspot, CursorMode.Auto);
    }

    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();


                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("swipe up");

                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");


                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                { 
                    Debug.Log("left swipe");
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                }
            }

            //Moved
            if (t.phase == TouchPhase.Moved)
            {
                pitch += Input.GetTouch(0).deltaPosition.y * Time.deltaTime * rotationSpeed;
                yaw += Input.GetTouch(0).deltaPosition.x * Time.deltaTime * rotationSpeed;

                pitch = Mathf.Clamp(yaw, -90, 90);

                this.transform.eulerAngles = new Vector3(pitch, yaw, 0);
            }
        }

    }
    

}
