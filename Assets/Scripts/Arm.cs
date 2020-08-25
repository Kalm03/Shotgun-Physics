using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public float speed = 300f;
    public Rigidbody2D rb;
    public Camera cam;

    public float offset = 90f;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (Input.GetMouseButton(1))
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, offset+ rotZ, speed * Time.fixedDeltaTime));
        }
    }
}
