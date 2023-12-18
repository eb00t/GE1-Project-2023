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
    private Animator WallAnim, PlanetAnims, MoonAnims;
    private GameObject WallParent, PlanB, PlanBM, PlanC;
    private Rigidbody WallRig;
    private Animator FloorAnim;
    private GameObject Asteroid;
    private Vector3 StartScale, TargetScale, PreMoonPos;
    private bool FirstActivate, SecondActivate;
    private GameObject DropTrig1, DropTrig2;
    public TColl TColl;
    public int AsteroidCount;
    


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
        DropTrig1 = GameObject.Find("DropTrig1");
        DropTrig2 = GameObject.Find("DropTrig2");
        PlanetAnims.SetBool("Stop", false);
        PlanC.GetComponent<Animator>().SetBool("CShrink", false);
        FirstActivate = false;
        PlanB = GameObject.Find("PlanB");
        MoonAnims = PlanB.GetComponent<Animator>();
        PlanBM = GameObject.Find("PlanBMoon");
        for (int i = 0; i < AsteroidCount; i++)
        {
            Asteroid = Instantiate(Resources.Load<GameObject>("Prefabs/Asteroid"),
                new Vector3(Random.Range(Random.Range(160.0f, 400.0f), Random.Range(-160.0f, -400.0f)),
                    Random.Range(100.0f, -100.0f), Random.Range(-400.0f, 400.0f)), Quaternion.identity);
            Asteroid.transform.rotation = Random.rotation;
            Asteroid.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),Random.Range(-5f,5f)), ForceMode.Impulse); 
        }
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
            StartCoroutine(PlanetDrop());
        }
        if (TColl.Hit == 3 && FirstActivate == false)
        {
            FirstActivate = true;
            StartCoroutine(PlanetC());
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

    private IEnumerator PlanetDrop()
    {
        MoonAnims.GetComponent<Animator>().enabled = false;
        yield return new WaitForSecondsRealtime(7f);
        PlanetAnims.SetBool("Shrink", true);
        yield return new WaitForSecondsRealtime(3f);
        PlanB.SetActive(false);
        DropTrig1.SetActive(true);
        FirstActivate = false;
    }

    private IEnumerator PlanetC()
    {
        yield return new WaitForSecondsRealtime(7f);
        PlanC.GetComponent<Animator>().SetBool("CShrink", true);
        yield return new WaitForSecondsRealtime(3f);
        PlanC.SetActive(false);
        DropTrig2.SetActive(true);
        FirstActivate = false;
    }
}
