using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{
    public GameObject hitg;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hitg, transform.position, Quaternion.identity);
        if (collision.collider.CompareTag("Respawn"))
        {
            StickmanController.health = 0;
        }
    }
}
