using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBuilding : BuildingBase
{
    private BuildBloken buildBloken = null;
    [SerializeField]
    private BillHitToCat hitToCat;

    [SerializeField] private SoundChild soundChild;

    // Start is called before the first frame update
    void Start()
    {
        buildBloken = this.GetComponent<BuildBloken>();
    }

    // Update is called once per frame
    void Update()
    {
        if (base.IsBroken() == true)
        {
            state = State.breaking;
            buildBloken.OnBleak();
            DeleteHingeJointsChildren();
            //buildBloken = null;
        }
        if (hitToCat.IsHit == true)
        {
            soundChild.oneshot = true;
            Debug.Log("aaa");
            hitToCat.PopupHitObject();
            base.life -= 1;
        }
        
    }
}
