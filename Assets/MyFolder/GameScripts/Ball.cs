using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ball : MonoBehaviour {

    public static float BallSpeed = 0.75f;
    public bool StopBall = false;
    public ColorController colorCt; //Script
    GameObject ballZipZipTriggerObject;
    public int BallColorIndex;
    public GameProperties gameProperties;
    public SceneManager sceneManager;
    public RandomGameProperties randGamePro;
    public Transform TouchArea;
    public static Transform thisObject;
    public static bool AnyColorWaiting = false;
    public SlowSkill slowskill;
    public AnyColorSkill anycolorskill;
    public Transform shadowBall;

    public void Start()
    {
        this.gameObject.transform.GetComponent<SpriteRenderer>().color = colorCt.CubesColor[colorCt.rntBall];
        this.gameObject.transform.parent.GetComponent<Animator>().SetTrigger("GameStart");
        this.gameObject.transform.parent.GetComponent<Animator>().speed = BallSpeed;
        TouchArea.gameObject.SetActive(false);
        thisObject = this.transform;

    }

    public void GameStart()
    {
        this.gameObject.transform.GetComponent<SpriteRenderer>().color = colorCt.CubesColor[colorCt.rntBall];
        this.gameObject.transform.parent.GetComponent<Animator>().SetTrigger("GameStart");
        this.gameObject.transform.parent.GetComponent<Animator>().speed = BallSpeed;
        TouchArea.gameObject.SetActive(true);
        
    }

    public void ZiplamadanSonra()
    {
        this.gameObject.transform.parent.GetComponent<Animator>().speed = BallSpeed;
        StopBall = false;
        shadowBall.gameObject.SetActive(true);

        if (AnyColorWaiting)
        {
            colorCt.numberColorList.Clear();
            colorCt.RandomColorNumber();
            colorCt.CubesColorChange();

            AnyColorWaiting = false;
        }

    }

    public void Zipladiginda()
    {
        ballZipZipTriggerObject.transform.parent.GetComponent<Animator>().SetTrigger("parentup");

        if (ballZipZipTriggerObject.transform.GetComponent<CubesController>().ColorIndex == colorCt.rntBall)
        {
            colorCt.ColorBall();
            this.gameObject.transform.GetComponent<SpriteRenderer>().color = colorCt.CubesColor[colorCt.rntBall];
            ballZipZipTriggerObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("hitcoins");
            gameProperties.inGameCoins++;

       
            if(BallSpeed <= 1.95f)
            {
                BallSpeed += 0.025f;

            }
 
            RandomGameProperties.GameLevel++;
            randGamePro.Olustur();
            randGamePro.InsParentMove();

        }
        else
        {
            BallSpeed = 0.75f;
            StopBall = true;

            if(sceneManager.gameProto.inGameCoins >= sceneManager.gameProto.MissionsCoins[sceneManager.gameProto.missionsId])
            {
                gameProperties.inGameCoins += 15;

                sceneManager.OyunBitti(gameProperties.inGameCoins, true);

            }
            else
            {
                sceneManager.OyunBitti(gameProperties.inGameCoins, false);

            }

            TouchArea.gameObject.SetActive(false);

        }

    }
    public void SagaVeSolaGeldiginde()
    {
        if (!AnyColorWaiting)
        {
            colorCt.CubesColorChange();
            colorCt.numberColorList.Clear();
        }
        else
        {
            colorCt.cubesColorAnyChange();
            colorCt.numberColorList.Clear();

        }

    }

    public void SagdanveyaSoldanAyrildiginda()
    {
        if (!AnyColorWaiting)
        {
            colorCt.RandomColorNumber();

        }
        else
        {
            colorCt.cubesColorAnyChange();
            colorCt.numberColorList.Clear();

        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "randomObjects")
        {
            if(col.gameObject.transform.GetComponent<RandomObjects>().whichObject == "anycolor")
            {
                gameProperties.AnyColorItem += 1;
                anycolorskill.ButtonSkills();
                sceneManager.SkillsTextRefresh();
                anycolorskill.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("action");
                gameProperties.WriteAnyColor();
                col.gameObject.transform.GetComponent<Animator>().SetTrigger("destroy");

            }
            else if (col.gameObject.transform.GetComponent<RandomObjects>().whichObject == "slow")
            {
                gameProperties.SlowItem += 1;
                slowskill.ButtonSkill();
                sceneManager.SkillsTextRefresh();
                slowskill.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("action");
                gameProperties.WriteSlow();
                col.gameObject.transform.GetComponent<Animator>().SetTrigger("destroy");


            }
            else if (col.gameObject.transform.GetComponent<RandomObjects>().whichObject == "coins1")
            {
                gameProperties.inGameCoins+=1;
                col.gameObject.transform.GetComponent<Animator>().SetTrigger("destroy");


            }
            else if (col.gameObject.transform.GetComponent<RandomObjects>().whichObject == "coins2")
            {
                gameProperties.inGameCoins+=2;
                col.gameObject.transform.GetComponent<Animator>().SetTrigger("destroy");


            }
            else if (col.gameObject.transform.GetComponent<RandomObjects>().whichObject == "coins5")
            {
                gameProperties.inGameCoins+=5;
                col.gameObject.transform.GetComponent<Animator>().SetTrigger("destroy");


            }
            else if (col.gameObject.transform.GetComponent<RandomObjects>().whichObject == "coins10")
            {
                gameProperties.inGameCoins+=10;
                col.gameObject.transform.GetComponent<Animator>().SetTrigger("destroy");


            }

        }

        ballZipZipTriggerObject = col.gameObject;
    
        

    }

  
}
