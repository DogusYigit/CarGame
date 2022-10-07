using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 1*turnSpeed, 0));
    }
}
