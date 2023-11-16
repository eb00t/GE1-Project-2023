using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Walls;
    private Rigidbody WallRig;
    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("BreakAway");
        /*foreach (GameObject gm in Walls)
        {
            WallRig = gm.GetComponent<Rigidbody>();
            WallRig.constraints = RigidbodyConstraints.FreezeAll;
            WallRig.useGravity = true;
        }*/
    }

    void Update()
    {
        if (TColl.Hit == true)
        {
            TColl.Hit = false;
            foreach (GameObject gm in Walls)
            {
                gm.AddComponent<Rigidbody>();
                WallRig = gm.GetComponent<Rigidbody>();
                WallRig.constraints = RigidbodyConstraints.FreezeAll;
                WallRig.useGravity = false;
            }
        }
    }
}
