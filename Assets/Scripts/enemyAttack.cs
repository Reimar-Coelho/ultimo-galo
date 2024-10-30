using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _damageAmount;
    private bool _isDamaging = false; // Flag para controlar o início do delay
    private bool _isInCollision = false; // Flag para monitorar se a colisão está ativa

    private void OnCollisionStay2D(Collision2D collision)
    {
        var healthController = collision.gameObject.GetComponent<Health>();

        if (healthController != null && healthController.RemainingHealthPercentage > 0)
        {
            _isInCollision = true; // Marca que o personagem está em colisão

            if (!_isDamaging)
            {
                // Aplica o dano imediatamente na primeira colisão
                healthController.TakeDamage(_damageAmount);
                StartCoroutine(DelayedDamage(healthController));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Marca que o personagem saiu da colisão
        if (collision.gameObject.GetComponent<Player>())
        {
            _isInCollision = false;
        }
    }

    private IEnumerator DelayedDamage(Health healthController)
    {
        _isDamaging = true; // Inicia o delay
        yield return new WaitForSeconds(3f); // Aguarda 3 segundos

        // Aplica o dano se o jogador ainda estiver em colisão e com vida
        if (_isInCollision && healthController.RemainingHealthPercentage > 0)
        {
            healthController.TakeDamage(_damageAmount);
        }

        _isDamaging = false; // Reseta a flag para permitir novos danos após o delay
    }
}
