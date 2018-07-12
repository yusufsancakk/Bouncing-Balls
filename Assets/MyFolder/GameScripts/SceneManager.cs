using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneManager : MonoBehaviour {

    public GameProperties gameProto;
    public ColorController ctControlScript;
    public Ball ballScriptDay;
    public Ball ballScriptNight;
    public SlowSkill slowSkills;
    public AnyColorSkill anyColorSkills;
    public bool GameisStarted = false;

    public Transform inGameCoins;
    TextMesh inGameCoinsTextMesh;
    public Transform inGameSlowItem;
    TextMesh inGameSlowItemTextMesh;
    public Transform inGameAnyColorItem;
    TextMesh inGameAnyColorItemTextMesh;
    public Transform inGameMissionItem;
    TextMesh inGameMissionTextMesh;
    public Transform gameFinishPanelCoinTextItem;
    TextMesh gameFinishPanelCoinTextMesh;
    public Transform gameFinishPanelADCoinTextItem;
    TextMesh gameFinishPanelADCoinTextMesh;
    public Transform mainPageCoinsTextItem;
    TextMesh mainPageCoinsTextMesh;

    public Transform OpactiyObject;
    public Transform GameFinishPage;
    public Transform MainPage;
    public Transform ShoppingPage;

    public Transform MapDayBG;
    public Transform MapNightBG;
    public Transform MapDayObjects;
    public Transform MapNightObjects;

    public Transform missionPanel;
    public AudioSource backgroundSound;


    public void Start()
    {
        inGameCoinsTextMesh = (TextMesh)inGameCoins.GetComponent(typeof(TextMesh));
        inGameSlowItemTextMesh = (TextMesh)inGameSlowItem.GetComponent(typeof(TextMesh));
        inGameAnyColorItemTextMesh = (TextMesh)inGameAnyColorItem.GetComponent(typeof(TextMesh));
        inGameMissionTextMesh = (TextMesh)inGameMissionItem.GetComponent(typeof(TextMesh));
        gameFinishPanelCoinTextMesh = (TextMesh)gameFinishPanelCoinTextItem.GetComponent(typeof(TextMesh));
        gameFinishPanelADCoinTextMesh = (TextMesh)gameFinishPanelADCoinTextItem.GetComponent(typeof(TextMesh));
        mainPageCoinsTextMesh = (TextMesh)mainPageCoinsTextItem.GetComponent(typeof(TextMesh));


    }

    public void SkillsTextRefresh()
    {
        inGameSlowItemTextMesh.text = gameProto.SlowItem.ToString();
        inGameAnyColorItemTextMesh.text = gameProto.AnyColorItem.ToString();
    }

    public void FixedUpdate()
    {
        
        if (GameisStarted)
        {
            inGameCoinsTextMesh.text = gameProto.inGameCoins.ToString();
            inGameSlowItemTextMesh.text = gameProto.SlowItem.ToString();
            inGameAnyColorItemTextMesh.text = gameProto.AnyColorItem.ToString();
            inGameMissionTextMesh.text = gameProto.MissionsText[gameProto.missionsId];

        }
        else
        {
            mainPageCoinsTextMesh.text = gameProto.Coins.ToString();
            inGameSlowItemTextMesh.text = gameProto.SlowItem.ToString();
            inGameAnyColorItemTextMesh.text = gameProto.AnyColorItem.ToString();
            inGameMissionTextMesh.text = gameProto.MissionsText[gameProto.missionsId];


        }
    }

    public void OyunBitti(int coins, bool mission)
    {
        OpactiyObject.gameObject.SetActive(true);
        GameFinishPage.gameObject.SetActive(true);
        GameisStarted = false;
        backgroundSound.volume = 0.1f;

        if (mission)
        {
            missionPanel.gameObject.SetActive(true);
            gameProto.missionsId += 1;

            gameFinishPanelCoinTextMesh.text = "$" + coins.ToString();

            if (coins <= 10)
            {
                gameFinishPanelADCoinTextMesh.text = "$40";

            }
            else
            {
                gameFinishPanelADCoinTextMesh.text = "$" + (coins * 2).ToString();

            }
        }
        else
        {
            gameFinishPanelCoinTextMesh.text = "$"+coins.ToString();

            if (coins <= 10)
            {
                gameFinishPanelADCoinTextMesh.text = "$25";

            }
            else
            {
                gameFinishPanelADCoinTextMesh.text = "$" + (coins * 2).ToString();

            }
        }

    }

    public void GameStart()
    {
        backgroundSound.volume = 0.5f;
        GameisStarted = true;
        anyColorSkills.ButtonSkills();
        slowSkills.ButtonSkill();
        ctControlScript.GameStart();
        ballScriptDay.GameStart();
        ballScriptNight.GameStart();

    }

}
