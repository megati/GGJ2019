using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPowerParticle : MonoBehaviour
{
    private Vector3 target = Vector3.zero;

    private Vector3 firstPosition = Vector3.zero;
    [SerializeField]
    AnimationCurve curve;

    public AudioClip clip;
    

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
        target = GameObject.Find("cannon").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        this.transform.position = Vector3.Slerp (firstPosition,target,curve.Evaluate( time / 2.0f));
    }
}
