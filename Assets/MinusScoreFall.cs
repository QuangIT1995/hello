using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusScoreFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.MinusScore(5);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
