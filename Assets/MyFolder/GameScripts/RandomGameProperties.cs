using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGameProperties : MonoBehaviour {

    public List<GameObject> RandomObjects = new List<GameObject>();
    public Transform InsParent;
    public static int GameLevel = 0;
    public static float sony=0;

    public void InsParentMove()
    {
        InsParent.position = new Vector3(InsParent.position.x, InsParent.position.y-2,InsParent.position.z);
    }

    public void Olustur()
    {
        float x = Random.Range(-0.18f, 8.09f);
        float yplus = Random.Range(3f, 5f);

        if (GameLevel % 12 == 0)
        {
            int rntBallSkills = Random.Range(0, 5);

            GameObject insObj = Instantiate(RandomObjects[rntBallSkills], InsParent);
            insObj.transform.localPosition = new Vector3(x, sony + yplus, 0);
            sony = insObj.transform.localPosition.y;

        }
        else if (GameLevel % 5 == 0)
        {
            int rntBallCoins = Random.Range(2, 5);

            GameObject insObj = Instantiate(RandomObjects[rntBallCoins], InsParent);
            insObj.transform.localPosition = new Vector3(x, sony + yplus, 0);
            sony = insObj.transform.localPosition.y;


        }

    }

}
