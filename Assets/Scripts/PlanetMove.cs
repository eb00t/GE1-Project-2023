using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMove : MonoBehaviour
{
    public bool Moving;
    public GameObject StartWP, EndWP;
    public List<GameObject> Waypoints;
    private GameObject Floor;
    [SerializeField] private float QuarterTime, StartTime;
    [SerializeField] private int i;

    void Start()
    {
        StartTime = Time.deltaTime;
        QuarterTime = 1f;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            Waypoints.Add(go);
        }
        StartWP = Waypoints[0];
        EndWP = Waypoints[1];
        i = 0;
        Moving = true;

        //Orbit();
    }

    void Update()
    {
        //Code modified from https://docs.unity3d.com/ScriptReference/Vector3.Slerp.html
        Vector3 OrbCentre = (StartWP.transform.position + EndWP.transform.position) * 0.5f;
        

        Vector3 HalfOneCentre = StartWP.transform.position - OrbCentre;
        Vector3 HalfTwoCentre = EndWP.transform.position - OrbCentre;

        float FracTime = (Time.deltaTime - StartTime) / QuarterTime;

        if (Moving)
        {
            transform.position = Vector3.Slerp(HalfOneCentre, HalfTwoCentre, FracTime);
            transform.position += OrbCentre;

            if (transform.position == HalfTwoCentre)
            {
                i++;
                if (i > 3)
                {
                    i = 0;
                }
                
                StartWP = Waypoints[i - 1];
                EndWP = Waypoints[i];
            }
        }
    }
}


