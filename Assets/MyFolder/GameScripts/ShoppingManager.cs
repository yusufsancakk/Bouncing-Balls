using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShoppingManager : MonoBehaviour {

    public GameProperties gp;
    public Text shoppingPageCoinsText;
    public int coinsForShop;
    public Animator SalesGoldAnim;
    public Transform NoHaveCoinsPage;
    public int selectedMap;

    public Transform mapDaySelectedItem;
    public Transform mapNightSelectedItem;
    public Transform mapNightPriceItem;

    public Button Skill01;
    public Button Skill02;
    float buttontime = 0f;

    public Transform LoadingPanel;

    public void Started()
    {
        coinsForShop = gp.Coins;
        shoppingPageCoinsText.text = gp.Coins.ToString();

        selectedMap = gp.mapId;

        if (coinsForShop <= 50)
        {
            NoHaveCoinsPage.gameObject.SetActive(true);
        }

        if (File.Exists(Application.persistentDataPath + "/Data/MapID.txt"))
        {
            mapNightPriceItem.gameObject.SetActive(false);
        }

        if (selectedMap == 0)
        {
            mapDaySelectedItem.gameObject.SetActive(true);
            mapNightSelectedItem.gameObject.SetActive(false);
        }
        else
        {
            mapDaySelectedItem.gameObject.SetActive(false);
            mapNightSelectedItem.gameObject.SetActive(true);
        }

        if(Time.deltaTime > 0)
        {
            Skill01.interactable = true;
            Skill02.interactable = true;

        }

        // 1 - iki haritaya da buton vererek gp scriptindeki pg.mapId yi değiştir, dosyayı yazdır ve sahneleri değiştir
        // satın alma işlemi gerçekleşirse mapId.txt doyası oluştur

    }

    public void SlowItemShopping()
    {
        if (coinsForShop >= 50)
        {
            coinsForShop -= 50;
            shoppingPageCoinsText.text = coinsForShop.ToString();
            SalesGoldAnim.SetTrigger("sale");
            gp.Coins -= 50;
            gp.SlowItem += 1;
            gp.WriteAll();

        }
        else
        {
            NoHaveCoinsPage.gameObject.SetActive(true);
        }
    }



    public void AnyColorItemShopping()
    {
        if (coinsForShop >= 75)
        {
            coinsForShop -= 75;
            shoppingPageCoinsText.text = coinsForShop.ToString();
            SalesGoldAnim.SetTrigger("sale");
            gp.Coins -= 75;
            gp.AnyColorItem += 3;
            gp.WriteAll();

        }
        else
        {
            NoHaveCoinsPage.gameObject.SetActive(true);

        }
    }


}
