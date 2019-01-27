using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPowerParticle : MonoBehaviour
{
    private Vector3 target = Vector3.zero;

    private Vector3 firstPosition = Vector3.zero;
    [SerializeField]
    AnimationCurve curve;

    public AudioClip clip;
    [SerializeField]
    private List<Sprite> sprites;
    

    private float time;
    public Image image;
    public 


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
        if (time < 2.0f) {
            this.transform.position = Vector3.Slerp(firstPosition, target, curve.Evaluate(time / 2.0f));
        }
        else if(time > 2.0f && time < 4.0f)
        {
            image.transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one,(time - 2.0f)/2.0f);
        }
    }
}
