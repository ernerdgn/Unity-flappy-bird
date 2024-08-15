using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;  // prefab var
    public float spawn_rate = 1f;  // rate of spawning
    public float min_height = -1f;  // height boundries
    public float max_height = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawn_rate, spawn_rate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));  // no need to spawn when game over
    }
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);  // "Instantiate" is using for copying the wanted existing object
        pipes.transform.position += Vector3.up * Random.Range(min_height, max_height);
    }
}
