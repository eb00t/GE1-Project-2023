using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpawn : MonoBehaviour
{
  public void SpawnPlanets()
  {
    TColl.BallB.GetComponent<Renderer>().enabled = true;
    TColl.BallB.GetComponent<Rigidbody>().isKinematic = false;
    TColl.HoopB.GetComponent<Renderer>().enabled = true;
  }

}
