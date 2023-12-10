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
    private GameObject PlanA, PlanB, PlanC;
    private GameObject PermaBallA, PermaBallB;
    private bool RB;
    public ParticleHandler ParticleHandler;
    // Start is called before the first frame update
    void Start()
    {
        ParticleHandler = GameObject.Find("BallA").GetComponent<ParticleHandler>();
        Ball = GameObject.Find("BallA");
        PlanA = gameObject.GetComponentInChildren<SearchTerm>().gameObject;
        PlanB = gameObject.GetComponentInChildren<SearchTerm>().gameObject;
        BallB = GameObject.FindWithTag("PlanetB");
        Hoop = gameObject;
        HoopB = GameObject.Find("BallHoop2");
        RB = false;
        BallB.GetComponent<Renderer>().enabled = false;
        HoopB.GetComponent<Renderer>().enabled = false;
        PermaBallA = GameObject.Find("Blank");
        PermaBallB = GameObject.Find("Blank");
    }

    private void Update()
    {
        PermaBallA.transform.position = PlanA.transform.position;
        PermaBallB.transform.position = PlanB.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Ball = other.gameObject;
        BallBody = Ball.GetComponent<Rigidbody>();
        BallColl = Ball.GetComponent<Collider>();
        if (other.gameObject.CompareTag("PlanetA"))
        {
            Ball.transform.SetParent(PlanA.transform);
            BallBody.isKinematic = true;
            Hit = 1;
            BallColl.enabled = false;
            PermaBallA = Ball;
        }
        if (other.gameObject.CompareTag("PlanetB"))
        {
            Ball.transform.SetParent(PlanB.transform);
            BallBody.isKinematic = true;
            Hit = 2;
            BallColl.enabled = false;
            PermaBallB = Ball;
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
            Hoop.GetComponent<Rigidbody>().isKinematic = true;
            //ParticleHandler.BallTrail = Ball.GetComponentInChildren<TrailRenderer>();
            //ParticleHandler.BallTrail.gameObject.SetActive(false);
            //ParticleHandler.BallParticlesEmission.enabled = true;
        }
    }
    
}
