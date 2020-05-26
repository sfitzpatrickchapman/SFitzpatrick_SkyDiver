using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotAirBalloon_controller : MonoBehaviour
{
    private float speed; // going to want increasing speed for accelerating effect
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed += 0.7f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).y > 1.5)
            Destroy(this.gameObject); // destroys HAB when it leaves frame
    }
}
