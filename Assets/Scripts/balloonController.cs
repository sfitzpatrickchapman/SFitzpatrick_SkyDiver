using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloonController : MonoBehaviour
{
    private float speed = 0.5f;
    private Rigidbody2D rb;
    private Text scoreText;
    public AudioClip balloonAudioClip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed); // velocity (x,y) <-- only moves on x axis, might want to make speed increase later
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); // finds score text and gets the actual text
    }

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1.5)
            Destroy(this.gameObject); // destroys balloon when it leaves frame
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        { // when balloon collides with player -->
            AudioSource.PlayClipAtPoint(balloonAudioClip, transform.position);
            GameObject.Destroy(this.gameObject);
            scoreText.transform.parent.GetComponent<ScoreController>().score += 20;
            scoreText.transform.parent.GetComponent<ScoreController>().UpdateScore(); // rewrites text component
        }
    }
}
