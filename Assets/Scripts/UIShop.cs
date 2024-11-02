using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : MonoBehaviour
{
    [SerializeField]
    private Sprite Minigun;
    [SerializeField] private Sprite M4;

    private Transform container;
    private Transform shopItemTemplate;
    public static bool StAK;
    public static bool StM4;
    public static bool StMinigun;

    private enum ItemType
    {
        M4,
        Minigun
    }
    private void Awake()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);

    }

    private void Start()
    {
        CreateItemButton(ItemType.M4,M4, "M4", 10, 0);
        CreateItemButton(ItemType.Minigun, Minigun, "Minigun", 30, 1);
        Hide();
    }

    private void CreateItemButton(ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("Value").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("Item").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () =>
        {
            TryBuyItem(itemType);
        };
    }

    private void TryBuyItem(ItemType itemType)
    {
        if (itemType == ItemType.M4)
        {
            Debug.Log("clicou na m4");
            if (StM4 == false)
            {
                if (Money.totalMoney < 10)
                {
                    return;
                }
                if (Money.totalMoney >= 10)
                {
                    Money.totalMoney -= 10;
                    StAK = false;
                    StMinigun = false;
                    StM4 = true;
                }
            }
            
        }
        if (itemType == ItemType.Minigun)
        {
            Debug.Log("clicou na minigun");
            if (StMinigun == false)
            {
                if (Money.totalMoney < 30)
                {
                    return;
                }
                if (Money.totalMoney >= 30)
                {
                    Money.totalMoney -= 30;
                    StAK = false;
                    StMinigun = true;
                    StM4 = false;
                }
            }
            
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
