using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    public Vector3 StartPos;
    private Rigidbody ObjRB;

    void Start()
    {
        StartPos = gameObject.transform.position;
        ObjRB = GetComponent<Rigidbody>();
        ObjRB.isKinematic = false;
    }

    public void Reset()
    {
        gameObject.transform.position = StartPos;
        ObjRB.isKinematic = true;
        StartCoroutine(Unfreeze());
    }

    private IEnumerator Unfreeze()
    {
        ObjRB.isKinematic = false;
        yield break;
    }
}