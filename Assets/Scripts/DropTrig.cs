using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropTrig : MonoBehaviour
{
    public int Drops;
    private GameObject FinalHoop, FinalBall;
    private bool HoopSpawned;
    void Start()
    { 
        HoopSpawned = false;
        gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "DropTrig1" && other.CompareTag("Player"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("DropTrig1"))
            {
                go.AddComponent<Rigidbody>();
                go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),Random.Range(-5f,5f)), ForceMode.Impulse); 
            }
            Drops++;
            gameObject.SetActive(false);
        }
        if (gameObject.name == "DropTrig2" && other.CompareTag("Player"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("DropTrig2"))
            {
                go.AddComponent<Rigidbody>();
                go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),Random.Range(-5f,5f)), ForceMode.Impulse); 
            }
            Drops++;
            gameObject.SetActive(false);
        }

        if (Drops == 2 && HoopSpawned == false)
        {
            HoopSpawned = true;
            FinalHoop = Instantiate(Resources.Load<GameObject>("Prefabs/FinalHoop"), new Vector3(0,0,0),
                Quaternion.identity);
        }
    }
}
