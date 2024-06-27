using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendTimeFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ExtendTime(5);
            Destroy(gameObject);
        }
    }
}
