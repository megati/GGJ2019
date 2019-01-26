using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBullet : BulletBase
{
    private Vector3 velocitySpeed = Vector3.zero;
    [SerializeField]
    private float firstSpeed = 0;
    [SerializeField]
    private Rigidbody rigidBody = null;
    [SerializeField]
    private List<HitJoint> hitJoints = new List<HitJoint>();

    // Start is called before the first frame update
    void Start()
    {
        velocitySpeed = this.transform.forward * firstSpeed;
        // デバッグ用のやつ
        //velocitySpeed = Vector3.forward * firstSpeed;
        rigidBody.AddForce( velocitySpeed, ForceMode.Impulse );
        var hits = GetComponentsInChildren<HitJoint>();
        for( int i = 0; i < hits.Length; ++i )
        {
            hitJoints.Add(hits[i]);
        }
    }

    // Update is called once per frame
    
    void Update()
    {
        //Vector3 direction = rigidBody.velocity.normalized;
        //this.transform.rotation = Quaternion.Euler(direction);
        bool isHit = false;
        GameObject hitObject = null;
        foreach ( var hitJoint in hitJoints )
        {
            if (hitJoint.isHit == true)
            {
                isHit = true;
                hitObject = hitJoint.HitObject;
            }
        }

        if (isHit == true)
        {
            SetJoint(hitObject);
            Destroy(this);
        }


    }
    
    void SetJoint(GameObject hitObjent)
    {
        foreach (var hitJoint in hitJoints)
        {
            Debug.Log("Set Joint" + hitObjent.name);
            if (hitObjent.GetComponent<Rigidbody>() != null)
            {
                var hinge = hitObjent.AddComponent<HingeJoint>();
                hinge.connectedBody = GetComponent<Rigidbody>();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
