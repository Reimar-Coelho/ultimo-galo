using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damageAmount = 10f; // Valor de dano da bala

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemyHealth = collision.GetComponent<Health>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount); // Aplica dano ao inimigo
            Destroy(gameObject); // Destroi a bala após o impacto
        }
    }
}
