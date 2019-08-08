using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectcolliderDestroy : MonoBehaviour
{
    [SerializeField] private AudioClip _swallowSFX;
    bool isScalingdown;
    AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        

        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _swallowSFX;
        _audioSource.playOnAwake = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isScalingdown == true)
        {
            transform.Translate(Vector3.up * 15 * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 8.0f * Time.deltaTime);

            

            if (transform.localScale == Vector3.zero)
            {
                isScalingdown = false;
            }
        }
    }


  

    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 intialScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(this.gameObject);
            isScalingdown = true;
            _audioSource.Play();
            Destroy(this.gameObject, 3f);

        }
    }
}
