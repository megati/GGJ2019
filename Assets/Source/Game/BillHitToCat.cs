using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillHitToCat : MonoBehaviour
{
    private List<GameObject> hitObjectList = new List<GameObject>();

    public bool IsHit
    {
        get
        {
            return hitObjectList.Count > 0;
        }
    }

    public GameObject PopupHitObject()
    {
        if (IsHit == true)
        {
            GameObject gameObject = hitObjectList[0];
            hitObjectList.Remove(gameObject);
            return gameObject;
        }
        return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(""+collision.gameObject.GetComponent<BulletBase>() != null);
        // ねこにはあたらんぜよ
        //if ((collision.gameObject.GetComponent<BulletBase>() != null) || (collision.gameObject.GetComponent<HitJoint>() != null) && IsHit == false)
        if ((collision.gameObject.GetComponent<HitJoint>() != null) && IsHit == false)
        {
            Debug.Log("HIT!!!!!!!");
            hitObjectList.Add(collision.gameObject);
        }
    }

}
