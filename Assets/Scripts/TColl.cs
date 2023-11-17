using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TColl : MonoBehaviour
{
    private Collider TCollider, BallColl;
    public static bool Hit;
    private GameManager GameManager;
    private GameObject Ball;
    private Rigidbody BallBody;
    private GameObject PlanA;
    private bool Bald;
    // Start is called before the first frame update
    void Start()
    {
        PlanA = GameObject.Find("BBallHoop");
        Ball = GameObject.Find("BallA");
        BallColl = Ball.GetComponent<Collider>();
    }

    private void Update()
    {
        if (Bald == true)
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
    }

    private void OnTriggerExit(Collider other)
    {
        TCollider.enabled = false;
    }

    void TestWin()
    {
            Ball.transform.position = gameObject.transform.position;
    }
}
