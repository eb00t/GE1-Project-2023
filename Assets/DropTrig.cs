using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropTrig : MonoBehaviour
{
    
    void Start()
    {
       gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "DropTrig1" && other.CompareTag("Player"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("DropTrig1"))
            {
                go.AddComponent<Rigidbody>();
                go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f,5f),5f,Random.Range(-5f,5f)), ForceMode.Impulse); 
            }
            gameObject.SetActive(false);
        }
        if (gameObject.name == "DropTrig2" && other.CompareTag("Player"))
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("DropTrig2"))
            {
                go.AddComponent<Rigidbody>();
                go.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f,5f),5f,Random.Range(-5f,5f)), ForceMode.Impulse); 
            }
            gameObject.SetActive(false);
        }
    }
}
