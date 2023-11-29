using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    public GameObject BallTrail;
    private GameObject BallParticles;
    [NonSerialized] public ParticleSystem.EmissionModule BallParticlesEmission;
    public TColl TColl;

    void Start()
    {
        TColl = GameObject.Find("BBallHoop").GetComponent<TColl>();
        BallTrail = GameObject.Find("BallTrail");
        //Line Particles
        BallTrail.SetActive(true);
        //Success Particles
        BallParticles = GameObject.Find("BallParticles");
        BallParticlesEmission = BallParticles.GetComponent<ParticleSystem>().emission;
        BallParticlesEmission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        BallParticles.transform.position = gameObject.transform.position;
        BallTrail.transform.position = BallParticles.transform.position;

        if (TColl.BallBody.isKinematic)
        {
            BallTrail.SetActive(false);
        }
    }
}
