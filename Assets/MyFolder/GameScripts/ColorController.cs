using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

    public GameObject[] CubesDay;
    public GameObject[] CubesNight;
    public GameObject[] NightCubesLight;

    public Color[] CubesColor;
    public List<int> numberColorList = new List<int>();
    public int rntBall;
    public GameProperties gp;


    public void RandomColorNumber()
    {
      
        for (int i = 0; i < CubesColor.Length+1 ; i++)
        {

            int rnd = Random.Range(0, CubesColor.Length);

            if (!numberColorList.Contains(rnd))
            {
                numberColorList.Add(rnd);
            }
            else
            {
                rnd = Random.Range(0, CubesColor.Length);

                if (!numberColorList.Contains(rnd))
                {
                    numberColorList.Add(rnd);
                }
                else
                {
                    rnd = Random.Range(0, CubesColor.Length);

                    if (!numberColorList.Contains(rnd))
                    {
                        numberColorList.Add(rnd);
                    }


                }


            }
        }
        
    }

    public void GameStart()
    {
        RandomColorNumber();
        ColorBall();
        CubesColorChange();
    }

    public void ColorBall()
    {
        rntBall = Random.Range(0, CubesColor.Length);

    }

    public void cubesColorAnyChange()
    {
        if(gp.mapId == 0)//DAY
        {
            for (int i = 0; i < CubesDay.Length; i++)
            {
                CubesDay[i].transform.GetComponent<SpriteRenderer>().color = CubesColor[rntBall];
                CubesDay[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = CubesColor[rntBall];
                CubesDay[i].transform.GetChild(0).GetChild(0).GetComponent<CubesController>().ColorIndex = rntBall;

            }
        }
        else if (gp.mapId == 1) //NIGHT
        {
            for (int i = 0; i < CubesNight.Length; i++)
            {
                CubesNight[i].transform.GetComponent<SpriteRenderer>().color = CubesColor[rntBall];
                CubesNight[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = CubesColor[rntBall];
                CubesNight[i].transform.GetChild(0).GetChild(0).GetComponent<CubesController>().ColorIndex = rntBall;
                NightCubesLight[i].transform.GetComponent<SpriteRenderer>().color = CubesColor[rntBall];

            }

        }



    }

    public void CubesColorChange()
    {

        if (gp.mapId == 0)//DAY
        {

            for (int i = 0; i < CubesDay.Length; i++)
            {

                CubesDay[i].transform.GetComponent<SpriteRenderer>().color = CubesColor[numberColorList[i]];
                CubesDay[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = CubesColor[numberColorList[i]];
                CubesDay[i].transform.GetChild(0).GetChild(0).GetComponent<CubesController>().ColorIndex = numberColorList[i];

            }
        }
        else if (gp.mapId == 1)//NIGHT
        {

            for (int i = 0; i < CubesNight.Length; i++)
            {

                CubesNight[i].transform.GetComponent<SpriteRenderer>().color = CubesColor[numberColorList[i]];
                CubesNight[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = CubesColor[numberColorList[i]];
                CubesNight[i].transform.GetChild(0).GetChild(0).GetComponent<CubesController>().ColorIndex = numberColorList[i];
                NightCubesLight[i].transform.GetComponent<SpriteRenderer>().color = CubesColor[numberColorList[i]];

            }
        }


 
    
    }


}
