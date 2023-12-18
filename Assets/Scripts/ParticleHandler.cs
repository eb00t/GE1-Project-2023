using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    public TrailRenderer BallTrail;
    private ParticleSystem BallParticles;
    [NonSerialized] public ParticleSystem.EmissionModule BallParticlesEmission;

    void Start()
    {
        BallTrail = gameObject.GetComponentInChildren<TrailRenderer>();
        //Line Particles
        BallTrail.gameObject.SetActive(true);
        //Success Particles
        BallParticles = gameObject.GetComponentInChildren<ParticleSystem>();
        BallParticlesEmission = BallParticles.emission;
        BallParticlesEmission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        BallParticles.transform.localPosition = Vector3.zero;
        BallTrail.transform.localPosition = Vector3.zero;
    }
}
