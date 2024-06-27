using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostMove : MonoBehaviour
{
    public float speed = 2f;
    public float speedBoostDuration = 5f;
    public float speedBoostAmount = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(transform.position.x > Camera.main.orthographicSize * Camera.main.aspect) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            PlayerControl player = collision.gameObject.GetComponent<PlayerControl>();
            if (player != null) 
            {
                player.ActiveSpeedBoost(speedBoostAmount,speedBoostDuration);
            }
            Destroy(gameObject);
        }
    }
}
