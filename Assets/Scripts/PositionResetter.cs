using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PositionResetter : MonoBehaviour
{
    public Vector3 StartPos;
    private Rigidbody ObjRB;
    private AudioSource BounceSource;
    private List<AudioClip> Bounces;
    private int RNG;

    void Start()
    {
        StartPos = gameObject.transform.position;
        ObjRB = GetComponent<Rigidbody>();
        if (gameObject.CompareTag("PlanetA") || gameObject.CompareTag("FinalBall"))
        {
            ObjRB.isKinematic = false;
        }
        else
        {
            ObjRB.isKinematic = true;
        }
        
    }

    public void Reset()
    {
        gameObject.transform.position = StartPos;
        ObjRB.isKinematic = true;
        StartCoroutine(Unfreeze());
    }

    private IEnumerator Unfreeze()
    {
        if (gameObject.GetComponent<Renderer>() == enabled)
        {
            ObjRB.isKinematic = false;
        }
        else
        {
            ObjRB.isKinematic = true;
        }
        yield break;
    }
    
}