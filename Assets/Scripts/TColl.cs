using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TColl : MonoBehaviour
{
    private Collider TCollider, BallColl;
    public static bool Hit;
    private Part1 Part1;
    private GameObject Ball, Hoop;
    public Rigidbody BallBody;
    private GameObject PlanA;
    private bool Bald, RB;
    public ParticleHandler ParticleHandler;
    // Start is called before the first frame update
    void Start()
    {
        ParticleHandler = GameObject.Find("BallA").GetComponent<ParticleHandler>();
        PlanA = GameObject.Find("BallHold");
        Hoop = GameObject.Find("BBallHoop");
        Ball = GameObject.Find("BallA");
        BallBody = Ball.GetComponent<Rigidbody>();
        BallColl = Ball.GetComponent<Collider>();
        RB = false;
    }

    private void Update()
    {
        if (Bald)
        {
            Ball.transform.position = PlanA.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Ball.transform.SetParent(PlanA.transform);
        BallBody = Ball.GetComponent<Rigidbody>();
        BallBody.isKinematic = true;
        Bald = true;
        Hit = true;
        BallColl.enabled = false;
        if (RB == false)
        {
            RB = true;
            Hoop.AddComponent<Rigidbody>();
            Hoop.GetComponent<Rigidbody>().useGravity = false;
            ParticleHandler.BallParticlesEmission1.enabled = false;
            ParticleHandler.BallParticlesEmission2.enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        TCollider.enabled = false;
    }
    
}
