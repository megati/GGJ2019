using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBuilding : BuildingBase
{
    private BuildBloken buildBloken = null;
    [SerializeField]
    private BillHitToCat hitToCat;

    // Start is called before the first frame update
    void Start()
    {
        buildBloken = this.GetComponent<BuildBloken>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitToCat.IsHit == true)
        {
            Debug.Log("aaa");
            hitToCat.PopupHitObject();
            base.life -= 1;
        }
        if (base.IsBroken() == true)
        {
            state = State.breaking;
            buildBloken.OnBleak();
            DeleteHingeJointsChildren();
            //buildBloken = null;
        }
    }
}
