using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator _animator;
    public float movSpeed;
    private float speedX, speedY;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private GameObject healthBar; // Referência ao GameObject HealthBar

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Busca o GameObject "HealthBar" no Canvas do jogador
        healthBar = transform.Find("Canvas/HealthBar")?.gameObject;

        // Desabilita o HealthBar se estiver na cena "SampleScene"
        if (SceneManager.GetActiveScene().name == "SampleScene" && healthBar != null)
        {
            healthBar.SetActive(false);
        }
        _animator = GetComponent<Animator>();
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
        _animator.SetBool(name:"IsWalking", value:speedX != 0 || speedY !=0);
        
    }
}
