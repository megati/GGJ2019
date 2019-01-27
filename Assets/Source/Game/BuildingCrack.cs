using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCrack : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> crackList;

    [SerializeField]
    private SpriteRenderer crack;
    [SerializeField]
    private SpriteRenderer crack1;

    [SerializeField]
    private BuildingBase building;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (building.GetLife() == 3) {
            crack.sprite = crackList[0];
            crack1.sprite = crackList[0];
        }
        if (building.GetLife() == 2) {
            crack.sprite = crackList[1];
            crack1.sprite = crackList[1];
        }
        if (building.GetLife() == 1) {
            crack.sprite = crackList[2];
            crack1.sprite = crackList[2];
        }
    }
}
