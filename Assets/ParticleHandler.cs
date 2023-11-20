using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    private GameObject BallParticles1, BallParticles2;
    [NonSerialized] public ParticleSystem.EmissionModule BallParticlesEmission1;
    [NonSerialized] public ParticleSystem.EmissionModule BallParticlesEmission2;
    public TColl TColl;

    void Start()
    {
        TColl = GameObject.Find("BBallHoop").GetComponent<TColl>();
        //Line Particles
        BallParticles1 = GameObject.Find("BallParticles1");
        BallParticlesEmission1 = BallParticles1.GetComponent<ParticleSystem>().emission;
        BallParticlesEmission1.enabled = true;
        //Success Particles
        BallParticles2 = GameObject.Find("BallParticles2");
        BallParticlesEmission2 = BallParticles2.GetComponent<ParticleSystem>().emission;
        BallParticlesEmission2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        BallParticles1.transform.position = gameObject.transform.position;
        BallParticles1.transform.rotation = gameObject.transform.rotation;
        BallParticles2.transform.position = gameObject.transform.position;
    }
}
