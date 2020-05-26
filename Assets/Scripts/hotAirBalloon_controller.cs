using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotAirBalloon_controller : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;

    void Start()
    {
        speed += 0.7f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1.5)
            Destroy(this.gameObject); // destroys HAB when it leaves frame
    }
}
