using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{

    public _Muscle[] muscles;

    public bool Right;
    public bool Left;

    public Rigidbody2D rbRIGHT;
    public Rigidbody2D rbLEFT;

    public Vector2 WalkRightVector;
    public Vector2 WalkLeftVector;

    private float MoveDelayPointer;
    public float MoveDelay;

    public static int health = 100;
    public AudioSource ded;
    public GameObject retry, quit, red;

    private void Start()
    {
        health = 100;
        ded.volume = 1;
    }

    private void Update()
    {
        foreach (_Muscle muscle in muscles)
        {
            muscle.ActivateMuscle();
        }

        if (Input.GetAxisRaw("Horizontal")>0)
        {
            Right = true;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Left = true;
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            Left = false;
            Right = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("ded");
            foreach (_Muscle muscle in muscles)
            {
                muscle.DeactivateMuscle();
            }
        }

        while (Right == true && Left == false && Time.time > MoveDelayPointer)
        {
            Invoke("Step1Right", 0f);
            Invoke("Step2Right", 0.085f);
            MoveDelayPointer = Time.time + MoveDelay;
        }

        while (Left == true && Right == false && Time.time > MoveDelayPointer)
        {
            Invoke("Step1Left", 0f);
            Invoke("Step2Left", 0.085f);
            MoveDelayPointer = Time.time + MoveDelay;
        }

        if (health <=0)
        {
            if (!ded.isPlaying)
            {
                StartCoroutine("Die");
                //ded.Play();
            }
            

            foreach (_Muscle muscle in muscles)
            {
                muscle.DeactivateMuscle();
            }

            red.SetActive(true);
            quit.SetActive(true);
            retry.SetActive(true);

        }
    }

    public void Step1Right()
    {
        rbRIGHT.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbLEFT.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    public void Step2Right()
    {
        rbLEFT.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbRIGHT.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    public void Step1Left()
    {
        rbRIGHT.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbLEFT.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    public void Step2Left()
    {
        rbLEFT.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbRIGHT.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
    }

    IEnumerator Die()
    {
        ded.Play();
        yield return new WaitForSeconds(3f);

        ded.volume = 0;
    }
}
[System.Serializable]
public class _Muscle
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;

    public void ActivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
    }

    public void DeactivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, 0));
    }
}