using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    [SerializeField]
    private UIShop uishop;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        uishop.Show();
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        uishop.Hide();
    }
}
