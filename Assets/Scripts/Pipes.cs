using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f;  // speed of pipes
    private float destroy_line;  // edge for destroying the pipes

    private void Start()
    {
        destroy_line = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;  // get the destroy_line pos.x
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;  // move the pipes

        if (transform.position.x < destroy_line)
        {
            Destroy(gameObject);  // destroy the pipes when in the correct zone
        }
    }
}
