using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;  // get mesh renderer to animate background and ground
    public float anim_speed = 1f;  // animation speed

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();  // check and get the components for MeshRenderer
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(anim_speed * Time.deltaTime, 0);  // animate
    }
}
