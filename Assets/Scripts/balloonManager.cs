using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonManager : MonoBehaviour
{
    private float timer; // for spawns
    private float maxTimer; // for spawns
    public GameObject Balloon;

    private float timerMin = 4f;
    private float timerMax = 6f;

    void Start()
    {
        timer = 0; // for spawns
        maxTimer = Random.Range(timerMin, timerMax); // for spawns
    }

    void Update()
    {
        StartCoroutine("SpawnBalloonTimer");
    }

    void SpawnBalloon()
    {
        float y = -0.5f;
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 1f), y, 0));
        spawnPoint.z = -1;

        // Adjust x-axis position
        float dist = (this.transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        Vector3 BalloonSize = Balloon.GetComponent<Renderer>().bounds.size;
        spawnPoint.x = Mathf.Clamp(spawnPoint.x, leftBorder + BalloonSize.x / 2, rightBorder - BalloonSize.x / 2);

        GameObject.Instantiate(Balloon, spawnPoint, new Quaternion(0, 0, 0, 0));
    }

    IEnumerator SpawnBalloonTimer()
    {
        if (timer >= maxTimer && Time.timeScale != 0) // also makes sure game isn't paused
        {
            SpawnBalloon(); // spawn
            timer = 0;
            maxTimer = Random.Range(timerMin, timerMax);
        }

        timer += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }
}
