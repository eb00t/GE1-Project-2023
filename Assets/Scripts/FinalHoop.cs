using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FinalHoop : MonoBehaviour
{
    public int Score;
    private Animator HoopAnim;
    private GameObject Ball;
    void Start()
    {
        Ball = Instantiate(Resources.Load<GameObject>("Prefabs/FinalBall"), new Vector3(2.86f, -2.6f, 4f),
            Quaternion.identity);
        Score = 0;
        gameObject.SetActive(false);
        HoopAnim.SetBool("Teleport", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalBall"))
        {
            HoopAnim.SetBool("Teleport", true);
        }
    }
    
    public void Teleport()
    {
        Score++;
        Destroy(GetComponentInChildren<PositionResetter>().gameObject);
        Ball = Instantiate(Resources.Load<GameObject>("Prefabs/FinalBall"), new Vector3(2.86f, -2.6f, 4f),
            Quaternion.identity);
        transform.position = new Vector3(Random.Range(22.5f, -7.5f), 0, Random.Range(22.5f, -7.5f));
        HoopAnim.SetBool("Teleport", false);
    }
}
