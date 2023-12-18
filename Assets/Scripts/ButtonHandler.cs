using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    public UnityEvent ButtonPressed, TouchedByPlayer, Touched;
    private Animator WholeButtAnims, ButtonAnims;

    private void Start()
    {
//        WholeButtAnims = gameObject.transform.parent.GetComponent<Animator>();
//        ButtonAnims = GetComponent<Animator>();
    }

    public void Pressed()
    {
        Debug.Log("Button Pressed");
       // ButtonAnims.SetTrigger("Pressed");
        //WholeButtAnims.SetBool("FlyIn", false);
        ButtonPressed.Invoke();
    }
    
    public void NotPressed()
    {
        ButtonAnims.SetTrigger("Pressed");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TouchedByPlayer.Invoke();
        }
        else if (other.CompareTag("PlanetA") || other.CompareTag("PlanetB") || other.CompareTag("PlanetC") || other.CompareTag("FinalBall"))
        {
            Touched.Invoke();
        }
    }
}
