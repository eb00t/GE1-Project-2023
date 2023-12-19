using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private SceneManagement SceneManagement;
    private PositionResetter PositionResetter;

    private void Start()
    {
        SceneManagement = GameObject.Find("SceneManager").GetComponent<SceneManagement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManagement.ReloadScene();
        }
        else if (other.CompareTag("PlanetA") || other.CompareTag("PlanetB") || other.CompareTag("PlanetC") ||
                 other.CompareTag("FinalBall"))
        {
            other.GetComponent<PositionResetter>().Reset();
        }
    }
}
