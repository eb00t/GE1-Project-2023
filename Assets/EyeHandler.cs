using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeHandler : MonoBehaviour
{
    private GameObject EyeBall, Player;
    public bool End;
    public int Speed;
    private Animator EyeAnims;
    private GameObject BlackCanvas;
    private GameObject Floor;

    private SceneManagement SceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        EyeBall = GameObject.Find("Eyeball");
        EyeAnims = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        EyeAnims.SetBool("Interested", false);
        BlackCanvas = GameObject.Find("BlackCanvas");
        BlackCanvas.SetActive(false);
        Floor = GameObject.Find("Floor");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 Direction = EyeBall.transform.position - Player.transform.position;
        if (End)
        {
            Quaternion ToRotation = Quaternion.LookRotation(Direction, Vector3.up);
            EyeBall.transform.rotation =
                Quaternion.Lerp(EyeBall.transform.rotation, ToRotation, Speed * Time.deltaTime);
        }
    }

    public void EndAnims()
    {
        EyeAnims.SetBool("Interested", true);
    }

    public void FadeToBlack()
    {
        Floor.SetActive(false);
    }

}
