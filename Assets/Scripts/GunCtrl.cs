using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject AKObj;
    [SerializeField]
    private GameObject M4Obj;
    [SerializeField]
    private GameObject MinigunObj;
    void Update()
    {
        if (UIShop.StAK == true && UIShop.StM4 == false && UIShop.StMinigun == false)
        {
            AKObj.gameObject.SetActive(true);
            M4Obj.gameObject.SetActive(false);
            MinigunObj.gameObject.SetActive(false);
        }
        if (UIShop.StAK == false && UIShop.StM4 == true && UIShop.StMinigun == false)
        {
            AKObj.gameObject.SetActive(false);
            M4Obj.gameObject.SetActive(true);
            MinigunObj.gameObject.SetActive(false);
        }
        if(UIShop.StAK == false && UIShop.StM4 == false && UIShop.StMinigun == true)
        {
            AKObj.gameObject.SetActive(false);
            M4Obj.gameObject.SetActive(false);
            MinigunObj.gameObject.SetActive(true);
        }
    }
}
