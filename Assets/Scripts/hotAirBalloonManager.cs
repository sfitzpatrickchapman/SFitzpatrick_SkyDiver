using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotAirBalloonManager : MonoBehaviour
{
    private float timer; // for spawns
    private float maxTimer; // for spawns
    public GameObject hotAirBalloon;

    public float timerMin;
    public float timerMax;

    void Start()
    {
        timer = 0; // for spawns
        maxTimer = Random.Range(timerMin, timerMax); // for spawns
    }

    void Update()
    {
        StartCoroutine("SpawnHotAirBalloonTimer");
        timerMin -= 0.0002f; // causes more hot air ballons to be spawned over time
        timerMax -= 0.0002f;
    }

    void SpawnHotAirBalloon()
    {
        float y = -0.5f;
        Vector3 spawnPoint = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 1f), y, 0));
        spawnPoint.z = -2;

        // Adjust x-axis position
        float dist = (this.transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        Vector3 hotAirBalloonSize = hotAirBalloon.GetComponent<Renderer>().bounds.size;
        spawnPoint.x = Mathf.Clamp(spawnPoint.x, leftBorder + hotAirBalloonSize.x / 2, rightBorder - hotAirBalloonSize.x / 2);

        GameObject.Instantiate(hotAirBalloon, spawnPoint, new Quaternion(0, 0, 0, 0));
    }

    IEnumerator SpawnHotAirBalloonTimer()
    {
        if (timer >= maxTimer && Time.timeScale != 0) // also makes sure game isn't paused
        {
            SpawnHotAirBalloon(); // spawn
            timer = 0;
            maxTimer = Random.Range(timerMin, timerMax);
        }

        timer += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }
}
