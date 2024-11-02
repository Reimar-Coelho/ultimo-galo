using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCount : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text_money;
    void Update()
    {
        text_money.text = Money.totalMoney.ToString();
    }
}
