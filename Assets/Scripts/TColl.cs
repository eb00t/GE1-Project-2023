using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TColl : MonoBehaviour
{
    private Collider TCollider;
    public static bool Hit;
    private GameManager GameManager;
    private GameObject Ball;
    private Rigidbody BallBody;
    private GameObject PlanA;
    // Start is called before the first frame update
    void Start()
    {
        PlanA = GameObject.Find("PlanA");
        Ball = GameObject.Find("BallA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        Ball.transform.SetParent(PlanA.transform);
        Ball.transform.position = gameObject.transform.position;
        TCollider.enabled = false;
        BallBody = Ball.GetComponent<Rigidbody>();
        BallBody.constraints = RigidbodyConstraints.FreezeAll;
        Hit = true;
    }

    void TestWin()
    {
            Ball.transform.position = gameObject.transform.position;
    }
}
