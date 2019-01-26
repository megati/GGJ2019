using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJoint : MonoBehaviour
{

    public bool isHit { get; set; }
    private GameObject hitObject;
    public GameObject HitObject
    {
        get { return hitObject; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        hitObject = collision.gameObject;
        isHit = true;
    }

}
