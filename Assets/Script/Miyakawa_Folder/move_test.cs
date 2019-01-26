using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_test : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward/2);
    }
}
