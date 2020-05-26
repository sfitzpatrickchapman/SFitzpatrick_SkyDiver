using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Text scoreText;
    public GameObject gameOverText;
    public AudioClip crashAudioClip;
    public AudioClip gameOverAudioClip;
    private bool gameOverAudioClipHasBeenPlayed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // allows rigid body access & assign to var
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>(); // allows access to score
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BoundMovement(); // boundaries
        Flip();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal"); // gets left/right movement
        float moveX = x * speed; // how much movement
        rb.velocity = new Vector2(moveX, 0); // rigidbody reference
    }

    void BoundMovement()
    {
        float dist = (this.transform.position - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        Vector3 playerSize = GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 2, rightBorder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 2, bottomBorder - playerSize.y / 2),
        this.transform.position.z
        );
    }

    void Flip()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
            characterScale.x = -1;
        if (Input.GetAxis("Horizontal") > 0)
            characterScale.x = 1;
        transform.localScale = characterScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HotAirBalloon")
        {
            AudioSource.PlayClipAtPoint(crashAudioClip, transform.position);
            if (gameOverAudioClipHasBeenPlayed == false) // plays game over audio but only once
            {
                AudioSource.PlayClipAtPoint(gameOverAudioClip, transform.position);
                gameOverAudioClipHasBeenPlayed = true;
            }
            gameOverText.SetActive(true); // display game over
            StartCoroutine(ExecuteAfterTime(4)); // starts enumerator
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // go back to 1st scene
    }
}
