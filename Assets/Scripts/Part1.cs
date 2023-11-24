using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1 : MonoBehaviour
{
    //Wall Stuff
    public GameObject[] Walls;
    public GameObject[] PhaseFloors;
    private Animator WallAnim;
    private GameObject WallParent;
    private Rigidbody WallRig;
    private Animator FloorAnim;
    private GameObject Ding;
    private Vector3 StartScale, TargetScale;

    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("BreakAway");
        PhaseFloors = GameObject.FindGameObjectsWithTag("PhaseFloor");
    }

    void Update()
    {
        if (TColl.Hit)
        {
            foreach (GameObject gm in Walls)
            {
                gm.AddComponent<Rigidbody>();
                    WallRig = gm.GetComponent<Rigidbody>();
                    //WallRig.constraints = RigidbodyConstraints.FreezeAll;
                    WallRig.useGravity = false;
                    StartCoroutine(Disappear());
            }
            foreach (GameObject pf in PhaseFloors)
            {
                FloorAnim = pf.GetComponent<Animator>();
                FloorAnim.SetBool("Appear", true);
            }
            TColl.Hit = false;
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSecondsRealtime(7f);
        WallParent = GameObject.FindWithTag("WallParent");
        WallAnim = WallParent.GetComponent<Animator>();
        WallAnim.SetBool("Shrink", true);
        yield return new WaitForSecondsRealtime(3f);
        WallParent.SetActive(false);
        /*foreach (GameObject wall in Walls)
        {

            Code modified from https://forum.unity.com/threads/how-to-make-gameobject-gradually-decrease-in-size.1033645/
            StartScale = gameObject.transform.localScale;
            TargetScale = Vector3.one * 0.5f;
            wall.transform.localScale = Vector3.Slerp(StartScale, TargetScale, Time.deltaTime / 5f);*/
        //yield return new WaitForSecondsRealtime(3f);
        //Destroy(wall);
    }
}

