using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Walls;
    private Rigidbody WallRig;
    private GameObject Ding;
    private Vector3 StartScale, TargetScale;

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
            foreach (GameObject gm in Walls)
            {
                    gm.AddComponent<Rigidbody>();
                    WallRig = gm.GetComponent<Rigidbody>();
                    //WallRig.constraints = RigidbodyConstraints.FreezeAll;
                    WallRig.useGravity = false;
                    StartCoroutine(Disappear());
            }
            TColl.Hit = false;
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSecondsRealtime(7f);
        foreach (GameObject wall in Walls)
        {
            //Code modified from https://forum.unity.com/threads/how-to-make-gameobject-gradually-decrease-in-size.1033645/
            StartScale = gameObject.transform.localScale;
            TargetScale = Vector3.one * 0.5f;
            wall.transform.localScale = Vector3.Slerp(StartScale, TargetScale, Time.deltaTime / 10);
            //yield return new WaitForSecondsRealtime(3f);
            //Destroy(wall);
        }
    }
}
