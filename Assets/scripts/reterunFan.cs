using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reterunFan : MonoBehaviour
{
    public Vector3 rotateVector = new Vector3(0, 0, 1);
    public float speed = 20;
    void Update()
    {
        transform.Rotate(rotateVector * speed * Time.fixedDeltaTime);
    }
}

