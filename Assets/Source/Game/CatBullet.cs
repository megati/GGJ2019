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
    [SerializeField]
    private float walkSpeed = 0;
    [SerializeField]
    private Animator animator = null;


    private Vector3 firstScale = Vector3.zero;
    private Vector3 firstPosition = Vector3.zero;

    enum State
    {
        Flying,
        JointHit,
        GroundHit,
    };

    private State state = State.Flying;

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
        firstScale = animator.transform.localScale;
        firstPosition = transform.position;
    }

    // Update is called once per frame

    void Update()
    {
        //Vector3 direction = rigidBody.velocity.normalized;
        //this.transform.rotation = Quaternion.identity * Quaternion.Euler(Vector3.left);
        switch (state)
        {
            case  State.Flying:
                Flying();
                break;
            case State.JointHit:
                JointHit();
                break;

            case State.GroundHit:
                GroundHit();
                break;

            default:
                Debug.Log("Cat Error");
                break;
        }
        //this.transform.rotation = Quaternion.identity * Quaternion.Euler(Vector3.left);

        /*
        else
        {
            //空気抵抗的なやつは、ころしておく
            //rigidBody.AddForce(-velocitySpeed.normalized, ForceMode.Acceleration);
        }
       */
    }

    private void FixedUpdate()
    {
        if (state == State.Flying)
        {
            rigidBody.AddForce(Vector3.down * 10.0f, ForceMode.Acceleration);
        }
    }

    void Flying()
    {
        float moveZ = transform.position.z - firstPosition.z;
        //Debug.Log("movez:"+moveZ);
        float scaleAnimationTime = Mathf.Min(moveZ / scaleAnimationMaxDistance, 1.0f);
        Debug.Log("scaleAnimationTime:" + animationCurve.Evaluate(scaleAnimationMaxDistance));

        //animator.gameObject.transform.localScale = firstScale * animationCurve.Evaluate(scaleAnimationTime);

        GameObject hitObject = null;
        foreach (var hitJoint in hitJoints)
        {
            if (hitJoint.isHit == true)
            {
                state = State.JointHit;
                hitObject = hitJoint.HitObject;
            }
            else if (hitJoint.isGround == true)
            {
                state = State.GroundHit;
            }
        }

        if (state == State.JointHit)
        {
            SetJoint(hitObject);
            //Destroy(this);
        }
        else if(state == State.GroundHit)
        {
            Escape();
        }

    }

    private void JointHit()
    {
        
    }

    void Escape()
    {
        foreach (var hitJoint in hitJoints)
        {
            Destroy(hitJoint.gameObject);
        }

            bool isRight = this.transform.position.x > 0 ? true : false;
        if (isRight == true)
        {
            //this.transform.rotation = Quaternion.LookRotation(this.transform.position + Vector3.right*1000, Vector3.up);
            transform.LookAt(Vector3.right);
        }
        else
        {
            //this.transform.rotation = Quaternion.LookRotation(this.transform.position + Vector3.left*1000, Vector3.up);
            transform.LookAt(Vector3.left);
        }
        this.GetComponent<BoxCollider>().isTrigger = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        rigidBody.velocity = Vector3.zero;
        animator.SetTrigger("WarkingTrigger");
        transform.position = new Vector3( transform.position.x, 1.25f, transform.position.z );
    }

    void GroundHit()
    {
        bool isRight = this.transform.position.x > 0 ? true : false;
        if (isRight == true)
        {
            this.transform.rotation = Quaternion.LookRotation(this.transform.position + Vector3.right*1000, Vector3.up);
            //transform.LookAt(Vector3.right);
        }
        else
        {
            this.transform.rotation = Quaternion.LookRotation(this.transform.position + Vector3.left*1000, Vector3.up);
            //transform.LookAt(Vector3.left);
        }

        this.transform.position += transform.forward * walkSpeed * Time.deltaTime;
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

        foreach (var hitJoint in hitJoints)
        {
            Destroy(hitJoint.GetComponent<BoxCollider>());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
