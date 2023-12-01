using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    public UnityEvent ButtonPressed, Touched;
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

    private void OnTriggerExit(Collider other)
    {
        Touched.Invoke();
    }
}
