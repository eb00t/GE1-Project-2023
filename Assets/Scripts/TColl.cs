using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TColl : MonoBehaviour
{
    private Collider TCollider, BallColl;
    public static int Hit;
    private GameManager GameManager;
    public GameObject Ball, Hoop;
    public Rigidbody BallBody;
    public static GameObject BallB, HoopB;
    private GameObject PlanA, PlanB, PlanC, PlanD, PlanE;
    private bool BaldA, BaldB, RB;
    public ParticleHandler ParticleHandler;
    // Start is called before the first frame update
    void Start()
    {
        ParticleHandler = GameObject.Find("BallA").GetComponent<ParticleHandler>();
        Ball = GameObject.Find("BallA");
        PlanA = gameObject.GetComponentInChildren<SearchTerm>().gameObject;
        BallB = GameObject.FindWithTag("PlanetB");
        HoopB = GameObject.Find("BallHoop2");
        Hoop = GameObject.Find("BBallHoop");
        RB = false;
        BallB.SetActive(false);
        HoopB.SetActive(false);
    }

    private void Update()
    {
        if (BaldA)
        {
            Ball.transform.position = PlanA.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Hoop = gameObject;
        Ball = other.gameObject;
        BallBody = Ball.GetComponent<Rigidbody>();
        BallColl = Ball.GetComponent<Collider>();
        if (other.gameObject.CompareTag("PlanetA"))
        {
            Ball.transform.SetParent(PlanA.transform);
            BallBody.isKinematic = true;
            BaldA = true;
            Hit = 1;
            BallColl.enabled = false;
            
        }
        if (other.gameObject.CompareTag("PlanetB"))
        {
            Ball.transform.SetParent(PlanB.transform);
            BallBody.isKinematic = true;
            BaldB = true;
            Hit = 2;
            BallColl.enabled = false;
        }
        else
        {
            Debug.Log("Not a planet.");
        }
        
        if (RB == false)
        {
            RB = true;
            Hoop.AddComponent<Rigidbody>();
            Hoop.GetComponent<Rigidbody>().useGravity = false;
            ParticleHandler.BallTrail = Ball.GetComponentInChildren<TrailRenderer>();
            //ParticleHandler.BallTrail.gameObject.SetActive(false);
            ParticleHandler.BallParticlesEmission.enabled = true;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        TCollider.enabled = false;
    }*/
    
}
