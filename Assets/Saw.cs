using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float knockBackForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

        if(playerRb != null) 
        {
            Vector2 knockBackDirection = collision.transform.position - transform.position;
            knockBackDirection.Normalize();
            playerRb.AddForce(knockBackDirection * knockBackForce, ForceMode2D.Impulse);
        }

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if(playerHealth != null) 
        {
            playerHealth.TakeDamage(1);
        }
    }
}
