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

    [SerializeField]
    private AnimationCurve animationCurve = null;
    [SerializeField]
    private float scaleAnimationMaxDistance = 0;

    private Vector3 firstScale = Vector3.zero;
    private Vector3 firstPosition = Vector3.zero;


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
        firstScale = transform.localScale;
        firstPosition = transform.position;
    }

    // Update is called once per frame
    
    void Update()
    {
        //Vector3 direction = rigidBody.velocity.normalized;
        //this.transform.rotation = Quaternion.Euler(direction);

        float moveZ = transform.position.z - firstPosition.z;
        //Debug.Log("movez:"+moveZ);
        float scaleAnimationTime = Mathf.Min( moveZ / scaleAnimationMaxDistance, 1.0f);
        Debug.Log("scaleAnimationTime:" + animationCurve.Evaluate(scaleAnimationMaxDistance));

        transform.localScale = firstScale * animationCurve.Evaluate(scaleAnimationTime);

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
        else
        {
            //空気抵抗的なやつは、ころしておく
            //rigidBody.AddForce(-velocitySpeed.normalized, ForceMode.Acceleration);
        }
        
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(Vector3.down * 10.0f, ForceMode.Acceleration);
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
