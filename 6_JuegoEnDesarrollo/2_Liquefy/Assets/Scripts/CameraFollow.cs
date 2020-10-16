using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.Find("/Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != GameObject.FindGameObjectWithTag("Player").transform.position) {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        if (playerTransform != null) {
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
    }
}
