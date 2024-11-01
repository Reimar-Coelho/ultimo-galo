using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectable : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _moneyAmount;

    public void OnCollected(GameObject player)
    {
        return;
    }
}
