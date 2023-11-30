using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1 : MonoBehaviour
{
    //Wall Stuff
    public GameObject[] Walls;
    public GameObject[] PhaseFloors;
    public GameObject PhaseFloorsParent;
    public Animator ButtonAnim;
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
        PhaseFloorsParent = GameObject.Find("PhaseFloorsParent");
        ButtonAnim = GameObject.Find("InteractableButton").GetComponent<Animator>();
        ButtonAnim.SetBool("FlyIn", false);
        WallParent = GameObject.FindWithTag("WallParent");
        WallAnim = WallParent.GetComponent<Animator>();
        PhaseFloorsParent.SetActive(false);
    }

    void Update()
    {
        if (TColl.Hit)
        {
            foreach (GameObject gm in Walls)
            {
                gm.AddComponent<Rigidbody>();
                WallRig = gm.GetComponent<Rigidbody>();
                //WallRig.constraints = RigidbodyConstraints.FreezeAll
                WallRig.useGravity = false;
                StartCoroutine(Disappear());
            }

            TColl.Hit = false;
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSecondsRealtime(7f);

        WallAnim.SetBool("Shrink", true);
        yield return new WaitForSecondsRealtime(3f);
        WallParent.SetActive(false);
        ButtonAnim.SetBool("FlyIn", true);
        /*foreach (GameObject wall in Walls)
        {

            Code modified from https://forum.unity.com/threads/how-to-make-gameobject-gradually-decrease-in-size.1033645/
            StartScale = gameObject.transform.localScale;
            TargetScale = Vector3.one * 0.5f;
            wall.transform.localScale = Vector3.Slerp(StartScale, TargetScale, Time.deltaTime / 5f);*/
        //yield return new WaitForSecondsRealtime(3f);
        //Destroy(wall);
    }

    public void SpawnPlatforms()
    {
        
        PhaseFloorsParent.SetActive(true);
        foreach (GameObject pf in PhaseFloors)
        {
            FloorAnim = pf.GetComponent<Animator>();
            FloorAnim.SetBool("Appear", true);
        }
    }
}
