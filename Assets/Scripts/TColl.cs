using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TColl : MonoBehaviour
{
    private Collider TCollider, BallColl;
    public static int Hit;
    private GameManager GameManager;
    public GameObject Ball, Hoop;
    public Rigidbody BallBody;
    public static GameObject BallB, HoopB, BallC, HoopC;
    private GameObject PlanA, PlanB, PlanC;
    private GameObject PermaBallA, PermaBallB, PermaBallC;
    private bool RB;
    private Animator BallAnims;
    public ParticleHandler ParticleHandler;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        Hit = 0;
        Ball = GameObject.FindWithTag("PlanetA");
        ParticleHandler = Ball.GetComponent<ParticleHandler>();
        PlanA = gameObject.GetComponentInChildren<SearchTerm>().gameObject;
        PlanB = gameObject.GetComponentInChildren<SearchTerm>().gameObject;
        PlanC = gameObject.GetComponentInChildren<SearchTerm>().gameObject;
        BallB = GameObject.FindWithTag("PlanetB");
        Hoop = gameObject;
        HoopB = GameObject.Find("BallHoop2");
        RB = false;
        BallC = GameObject.FindWithTag("PlanetC");
        HoopC = GameObject.Find("BallHoop3");
        BallB.GetComponent<Renderer>().enabled = false;
        HoopB.GetComponent<Renderer>().enabled = false;
        BallC.GetComponent<Renderer>().enabled = false;
        HoopC.GetComponent<Renderer>().enabled = false;
        PermaBallA = GameObject.Find("Blank");
        PermaBallB = GameObject.Find("Blank");
        PermaBallC = GameObject.Find("Blank");
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PermaBallA.transform.position = PlanA.transform.position;
        PermaBallB.transform.position = PlanB.transform.position;
        PermaBallC.transform.position = PlanC.transform.position;
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
            AudioSource.PlayOneShot(AudioSource.GetComponent<AudioSource>().clip);
        }
        if (other.gameObject.CompareTag("PlanetB"))
        {
            Ball.transform.SetParent(PlanB.transform);
            BallBody.isKinematic = true;
            Hit = 2;
            BallColl.enabled = false;
            PermaBallB = Ball;
            AudioSource.PlayOneShot(AudioSource.GetComponent<AudioSource>().clip);
        }
        if (other.gameObject.CompareTag("PlanetC"))
        {
            Ball.transform.SetParent(PlanC.transform);
            BallBody.isKinematic = true;
            Hit = 3;
            BallColl.enabled = false;
            PermaBallC = Ball;
            AudioSource.PlayOneShot(AudioSource.GetComponent<AudioSource>().clip);
        }
        else
        {
            Debug.Log("Not a planet.");
        }
        
        if (RB == false && (other.CompareTag("PlanetA") || other.CompareTag("PlanetB") || other.CompareTag("PlanetC")))
        {
            RB = true;
            Hoop.AddComponent<Rigidbody>();
            Hoop.GetComponent<Rigidbody>().useGravity = false;
            Hoop.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),Random.Range(-5f,5f)), ForceMode.Impulse);
            other.GetComponent<ParticleHandler>().BallTrail.gameObject.SetActive(false);
            other.GetComponent<ParticleHandler>().BallParticlesEmission.enabled = true;
        }
    }
    
}
