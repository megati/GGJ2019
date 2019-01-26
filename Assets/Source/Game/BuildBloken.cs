using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBloken : MonoBehaviour
{

    [SerializeField]
    private GameObject build = null;

    [SerializeField]
    private AnimationCurve animationCurveX = null;

    [SerializeField]
    private ParticleSystem particle = null;

    private Vector3 firstPosition = new Vector3();
    private float animationTime = 0;
    private float buildMoveY = 0;
    [SerializeField]
    private float buildSpeedY = 10;


    // Start is called before the first frame update
    void Start()
    {
        firstPosition = build.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnBloken();
        }
        

    }


    private void OnBloken()
    {
        //particle.Play(true);
        StartCoroutine(StartBlokenAnimation());
    }

    private IEnumerator StartBlokenAnimation()
    {
        
        particle.Play();

        while (build.transform.position.y > -5) {
            //build.transform.position = firstPosition + new Vector3(animationCurveX.Evaluate(animationTime), buildMoveY);
            build.transform.position = firstPosition + new Vector3(Mathf.Sin(Mathf.Rad2Deg*animationTime) * 1, buildMoveY);

            animationTime += Time.deltaTime;
            buildMoveY += buildSpeedY * Time.deltaTime;
            if (animationTime > 1)
            {
                animationTime = 0;
            }
            yield return null;
        }
         particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return null;

    }

}
