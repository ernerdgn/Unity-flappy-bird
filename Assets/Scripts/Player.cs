using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;  // get sprite renderer to animate bird flapping
    public Sprite[] sprites;  // list that holds the sprites of birdie
    private int sprite_index;

    private Vector3 direction;  // dir variable to go up and down
    public float gravity = -10f;  // gravity -> 10 is realistic enough
    public float flap_str = 5f;  // hit the gym if you need birdie

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // check and get the "Player"s components for SpriteRenderer
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), .15f, .15f);  // invokes method in seconds, 15 miliseconds 
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;  // reset birdie's position when restart
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  // if mouse button or space is pressed
        {
            direction = Vector3.up * flap_str;  // FLAP!
        }

        direction.y += gravity * Time.deltaTime;  // apply gravity

        transform.position += direction * Time.deltaTime;  // update position of the sprite

        float angle = Mathf.Clamp(direction.y * 3f, -90,90);
        Debug.Log(angle);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void AnimateSprite()
    {
        sprite_index++;  // increasing the index

        if (sprite_index >= sprites.Length) sprite_index = 0;  // set boundry for index

        spriteRenderer.sprite = sprites[sprite_index];  // render next sprite
    }

    private void OnTriggerEnter2D(Collider2D collision)  // collision tests
    {
        if (collision.gameObject.tag == "Obstacle") FindObjectOfType<GameManager>().GameOver();  // if obstacle run gameover
        else if (collision.gameObject.tag == "Scoring") FindObjectOfType<GameManager>().IncreaseScore();  // elif scoring increase score
    }
}
