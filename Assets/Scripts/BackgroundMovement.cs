using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float scrollSpeed = 0.25f;
    public float clampPosition;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, clampPosition);
        transform.position = startPosition + Vector3.up * newPosition;
    }
}
