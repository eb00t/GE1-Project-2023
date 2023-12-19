using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FinalHoop : MonoBehaviour
{
    public int Score;
    private Animator HoopAnim;
    private GameObject Ball, PermaBall;
    void Start()
    {
        Ball = Instantiate(Resources.Load<GameObject>("Prefabs/FinalBall"), new Vector3(2.86f, -2.6f, 4f),
            Quaternion.identity);
        Score = 0;
        //gameObject.SetActive(false);
        HoopAnim = GetComponent<Animator>();
        HoopAnim.SetBool("Teleport", false);
        PermaBall = GameObject.Find("Blank");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalBall"))
        {
            other.transform.SetParent(gameObject.transform);
            Ball = PermaBall;
            HoopAnim.SetBool("Teleport", true);
            
        }
    }

    private void Update()
    {
        PermaBall.transform.localPosition = Vector3.zero;
    }

    public void Teleport()
    {
        Score++;
        Debug.Log(Score);
        Ball.transform.SetParent(null);
        Destroy(Ball);
        Ball = Instantiate(Resources.Load<GameObject>("Prefabs/FinalBall"), new Vector3(2.86f, -2.6f, 4f),
            Quaternion.identity);
        gameObject.transform.position = new Vector3(Random.Range(22.5f, -7.5f), 0, Random.Range(22.5f, -7.5f));
        HoopAnim.SetBool("Teleport", false);
    }
}
