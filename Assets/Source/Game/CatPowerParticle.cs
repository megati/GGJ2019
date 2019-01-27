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
    private int random;


    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
        target = GameObject.Find("cannon").transform.position;
        image = GameObject.Find("NekoPanel").GetComponent<Image>();
        random = Random.Range(0, 4);
        image.sprite = sprites[random];
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 2.0f) {
            this.transform.position = Vector3.Slerp(firstPosition, target, curve.Evaluate(time / 2.0f));
        }
        else if(time > 2.0f && time < 4.2f)
        {
            float t = (time - 2.0f) / 1.0f;
            image.transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one,t);
            image.color = new Color(1,1,1,1.0f-t);
        }
    }
}
