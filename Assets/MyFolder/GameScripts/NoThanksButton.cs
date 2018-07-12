using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoThanksButton : MonoBehaviour {

    public Transform close1;
    public Transform open1;
    public GameProperties gp;
    public SceneManager sm;

    public Transform RandomSkillsParent;

    public Transform inGameSlowSkill;
    TextMesh inGameSlowSkillMesh;

    public Transform inGameAnyColorSkill;
    TextMesh inGameAnyColorSkillMesh;

    public Transform missionPanel;

    private void Start()
    {
        inGameSlowSkillMesh = (TextMesh)inGameSlowSkill.GetComponent(typeof(TextMesh));
        inGameAnyColorSkillMesh = (TextMesh)inGameAnyColorSkill.GetComponent(typeof(TextMesh));

    }

    void OnMouseDown()
    {
        missionPanel.gameObject.SetActive(false);

        gp.Coins += gp.inGameCoins;
        gp.WriteAll();
        StartCoroutine(WaitFor1Time());

        gp.inGameCoins = 0;
        close1.gameObject.SetActive(false);
        open1.gameObject.SetActive(true);

        RandomGameProperties.GameLevel = 0;
        RandomGameProperties.sony = 0;

        RandomSkillsParent.position = new Vector3(-12.78f, 61.2f, 1f);

        foreach (Transform items in RandomSkillsParent.GetComponentInChildren<Transform>(true))
        {
            Destroy(items.gameObject);
        }

    }

    IEnumerator WaitFor1Time()
    {
        yield return new WaitForSeconds(1);
       
    }
}
