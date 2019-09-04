using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateTime : MonoBehaviour
{
    [SerializeField] private float _maxtime = 60;
    [SerializeField] private float _dangerTime = 10;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _maxtime -= Time.deltaTime;

        int secs = (int)_maxtime % 60;
        print("Seconds: "+ secs);

#if UNITY_EDITOR
        //print("_maxTime: " + Mathf.FloorToInt(_maxtime));
#endif

        if (_dangerTime > _maxtime)
        {
            //print(_maxtime);
            _maxtime = 20;
            
        }
    }
}
