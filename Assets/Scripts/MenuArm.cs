using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuArm : MonoBehaviour
{
    public float speed = 300f;
    public float offset = 90f;
    public float force = 25f;

    public Rigidbody2D rb;
    public Camera cam;

    

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, offset + rotZ, speed * Time.fixedDeltaTime));
        rb.velocity = (difference*force);
    }
}
