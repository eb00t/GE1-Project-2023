using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Wall Stuff
    public GameObject[] Walls;
    public GameObject[] PhaseFloors;
    public GameObject PhaseFloorsParent;
    public Animator ButtonAnim;
    private Animator WallAnim, PlanetAnims;
    private GameObject WallParent, PlanB, PlanBM;
    private Rigidbody WallRig;
    private Animator FloorAnim;
    private GameObject Ding;
    private Vector3 StartScale, TargetScale;
    private bool FirstActivate, SecondActivate;
    public TColl TColl;


    void Start()
    {
        Walls = GameObject.FindGameObjectsWithTag("BreakAway");
        PhaseFloors = GameObject.FindGameObjectsWithTag("PhaseFloor");
        PhaseFloorsParent = GameObject.Find("PhaseFloorsParent");
        PlanetAnims = GameObject.Find("PlanetB").GetComponent<Animator>();
        ButtonAnim = GameObject.Find("InteractableButton").GetComponent<Animator>();
        ButtonAnim.SetBool("FlyIn", false);
        WallParent = GameObject.FindWithTag("WallParent");
        WallAnim = WallParent.GetComponent<Animator>();
        PhaseFloorsParent.SetActive(false);
        PlanetAnims.SetBool("Stop", false);
        FirstActivate = false;
        PlanB = GameObject.Find("PlanB");
        PlanBM = GameObject.Find("PlanBMoon");
    }

    void Update()
    {
        if (TColl.Hit == 1 && FirstActivate == false)
        {
            FirstActivate = true;
            foreach (GameObject gm in Walls)
            {
                gm.AddComponent<Rigidbody>();
                WallRig = gm.GetComponent<Rigidbody>();
                //WallRig.constraints = RigidbodyConstraints.FreezeAll
                WallRig.useGravity = false;
                StartCoroutine(Disappear());
            }
        }
        if (TColl.Hit == 2 && FirstActivate == false)
        {
            FirstActivate = true;
            PlanB.GetComponent<Rigidbody>().useGravity = true;
            PlanB.GetComponent<Rigidbody>().isKinematic = false;
            PlanBM.GetComponent<Rigidbody>().useGravity = true;
            PlanBM.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSecondsRealtime(7f);

        WallAnim.SetBool("Shrink", true);
        yield return new WaitForSecondsRealtime(3f);
        WallParent.SetActive(false);
        ButtonAnim.SetBool("FlyIn", true);
        SpawnPlatforms();
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

        PlanetAnims.SetBool("Stop", true);
        PlanetAnims.speed = 3;
        FirstActivate = false;
    }
}
