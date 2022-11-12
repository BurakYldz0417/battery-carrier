using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{


    public float speed =1.2f;
    
    
    void Start()
    {
      
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(0, 0, -1*speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0, 0, 1*speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.down*speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(Vector3.up*speed);
        }

        if(speed>=4)
        {
            speed = 4;
        }
    }

}
   

