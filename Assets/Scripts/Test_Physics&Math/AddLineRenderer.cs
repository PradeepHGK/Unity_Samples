using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLineRenderer : MonoBehaviour
{

    public GameObject annotation;
    LineRenderer lineren;

    dynamic values;

    // Start is called before the first frame update
    void Start()
    {
        values = "LineRenderer";
        lineren = GetComponent<LineRenderer>();
       
    }

    //Using Dynamic keyword as method parameter
    void DynamicParamsMethods(dynamic values)
    {
        values = "Names";
        values = 22;
    }

    //Ternary operator
    void UserternaryOpe(int value, int value1)
    {
        var result = value > value1 ? value : value1;
        Debug.Log("ternaryOperator: " + result);
    }

    // Update is called once per frame
    void Update()
    {
        AddLinerender();

        /*
        if (Input.GetMouseButton(0))
        {
            var mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lineren.positionCount++;
            lineren.SetPosition(lineren.positionCount - 1, mouseposition);
        }


        if (Input.GetMouseButtonUp(0))
        {
            //    if (simplifyLine) 
            //    {
            //        line.Simplify(simplifyTolerance);
            //    }
        }
        */
    }

    private void AddLinerender()
    {
        
        Vector3 distance = annotation.transform.position - transform.position;
        //lineren.SetWidth(0.1f, 0.3f); //deprecated
        lineren.SetPosition(0, this.transform.position);
        lineren.SetPosition(1, distance);

    }
}
