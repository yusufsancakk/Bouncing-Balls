using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapPayAndSelect : MonoBehaviour {

    public int MapID;
    public ShoppingManager sm;
    public SceneManager smanager;
    public bool ReadyForSale = false;

	public void clickedThis () {
		
        if(!File.Exists(Application.persistentDataPath + "/Data/MapID.txt") && ReadyForSale)
        {
            if (sm.coinsForShop >= 500)
            {
                sm.LoadingPanel.gameObject.SetActive(true);

                File.Create(Application.persistentDataPath + "/Data/MapID.txt");

                StartCoroutine(WaitForSecondForSaveShop());

            }
            else
            {
                sm.NoHaveCoinsPage.gameObject.SetActive(true);
            }
        }
        else
        {

            if (File.Exists(Application.persistentDataPath + "/Data/MapID.txt")){

                sm.gp.mapId = MapID;
                sm.gp.WriteMap();
                sm.selectedMap = MapID;

                if (sm.gp.mapId == 0)
                {
                    sm.mapDaySelectedItem.gameObject.SetActive(true);
                    sm.mapNightSelectedItem.gameObject.SetActive(false);

                    smanager.MapDayBG.gameObject.SetActive(true);
                    smanager.MapDayObjects.gameObject.SetActive(true);
                    smanager.MapNightBG.gameObject.SetActive(false);
                    smanager.MapNightObjects.gameObject.SetActive(false);
                    

                }
                else
                {
                    sm.mapDaySelectedItem.gameObject.SetActive(false);
                    sm.mapNightSelectedItem.gameObject.SetActive(true);

                    smanager.MapDayBG.gameObject.SetActive(false);
                    smanager.MapDayObjects.gameObject.SetActive(false);
                    smanager.MapNightBG.gameObject.SetActive(true);
                    smanager.MapNightObjects.gameObject.SetActive(true);
                }
            }



        }




    }

    IEnumerator WaitForSecondForSaveShop()
    {
        yield return new WaitForSeconds(3);

        sm.coinsForShop -= 500;
        sm.shoppingPageCoinsText.text = sm.coinsForShop.ToString();
        sm.SalesGoldAnim.SetTrigger("sale");
        sm.gp.Coins -= 500;
        sm.gp.WriteAll();
        sm.gp.WriteMap();

        sm.LoadingPanel.gameObject.SetActive(false);

        if (File.Exists(Application.persistentDataPath + "/Data/MapID.txt"))
        {
            sm.mapNightPriceItem.gameObject.SetActive(false);
        }

    }
}
