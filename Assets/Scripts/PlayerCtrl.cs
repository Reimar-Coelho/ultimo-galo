using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        // Flip o sprite no eixo X dependendo da direção do movimento
        if (speedX > 0)
        {
            spriteRenderer.flipX = true; // Virado para a direita
        }
        else if (speedX < 0)
        {
            spriteRenderer.flipX = false; // Virado para a esquerda
        }
    }
}
