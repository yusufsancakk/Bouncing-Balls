using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameProperties : MonoBehaviour {

    public List<string> MissionsText = new List<string>();
    public List<int> MissionsCoins = new List<int>();

    public SceneManager sm;

    public int Coins = 0;
    public int SlowItem = 0;
    public int AnyColorItem = 0;
    public int inGameCoins = 0;
    public int missionsId = 0;
    public int mapId = 0;

    public void Start()
    {
        ReadAll();
    }

    public void ReadAll()
    {
        Coins = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Data/Coins.txt"));
        AnyColorItem = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Data/AnyColorSkills.txt"));
        SlowItem = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Data/SlowSkills.txt"));
        missionsId = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Data/MissionID.txt"));

        if (File.Exists(Application.persistentDataPath + "/Data/MapID.txt"))
        {
            mapId = int.Parse(File.ReadAllText(Application.persistentDataPath + "/Data/MapID.txt"));

            if (mapId == 0)
            {
                Debug.Log("dosya var ve gündüz");

                sm.MapDayBG.gameObject.SetActive(true);
                sm.MapDayObjects.gameObject.SetActive(true);
                sm.MapNightBG.gameObject.SetActive(false);
                sm.MapNightObjects.gameObject.SetActive(false);

            }
            else
            {
                Debug.Log("dosya var ve gece");

                sm.MapDayBG.gameObject.SetActive(false);
                sm.MapDayObjects.gameObject.SetActive(false);
                sm.MapNightBG.gameObject.SetActive(true);
                sm.MapNightObjects.gameObject.SetActive(true);

            }
        }
        else
        {
            Debug.Log("dosya yok ve gündüZ");

            sm.MapDayBG.gameObject.SetActive(true);
            sm.MapDayObjects.gameObject.SetActive(true);
            sm.MapNightBG.gameObject.SetActive(false);
            sm.MapNightObjects.gameObject.SetActive(false);
        }



    }

    public void WriteAnyColor()
    {
        File.WriteAllText(Application.persistentDataPath + "/Data/AnyColorSkills.txt", AnyColorItem.ToString());

    }

    public void WriteSlow()
    {
        File.WriteAllText(Application.persistentDataPath + "/Data/SlowSkills.txt", SlowItem.ToString());

    }

    public void WriteMap()
    {
        File.WriteAllText(Application.persistentDataPath + "/Data/MapID.txt", mapId.ToString());

    }
    public void WriteAll()
    {
        File.WriteAllText(Application.persistentDataPath + "/Data/Coins.txt", Coins.ToString());
        File.WriteAllText(Application.persistentDataPath + "/Data/SlowSkills.txt", SlowItem.ToString());
        File.WriteAllText(Application.persistentDataPath + "/Data/AnyColorSkills.txt", AnyColorItem.ToString());
        File.WriteAllText(Application.persistentDataPath + "/Data/MissionID.txt", missionsId.ToString());

        if (File.Exists(Application.persistentDataPath + "/Data/MapID.txt"))
        {
            File.WriteAllText(Application.persistentDataPath + "/Data/MapID.txt", mapId.ToString());

        }


    }

}
