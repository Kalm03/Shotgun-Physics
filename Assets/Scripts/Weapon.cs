using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;

    public GameObject shotEffect;
    public AudioSource shooty;
    public Transform shotPoint;

    public Rigidbody2D rb;

    public CamShake cs;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float KnockForce = 50f;

    private void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
                shooty.Play();
                Instantiate(projectile, shotPoint.position, transform.rotation);
                cs.ShakeCam(2.5f, .1f);

                rb.AddForce(-1 * KnockForce*difference);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }

    
}