using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public List<GameObject> AllObjects;
    void Start()
    {
        foreach (GameObject go in FindObjectsOfType<GameObject>())
        {
            AllObjects.Add(go);
            
            if (go.transform.parent.CompareTag("Exclude"))
            {
                AllObjects.Remove(go);
            }
            if (go.CompareTag("Exclude"))
            {
                AllObjects.Remove(go);
            }
            
        }
    }
}
