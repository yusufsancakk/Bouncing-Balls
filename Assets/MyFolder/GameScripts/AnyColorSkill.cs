using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyColorSkill : MonoBehaviour {

    public SceneManager sm;
    public GameProperties gp;


    public Transform circleCoins;

    public void ButtonSkills()
    {

        if (sm.GameisStarted && (gp.AnyColorItem >= 1))
        {
            this.gameObject.transform.GetComponent<CircleCollider2D>().enabled = true;
            this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            circleCoins.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetComponent<CircleCollider2D>().enabled = false;
            this.gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            circleCoins.gameObject.SetActive(false);
        }

    }

    void OnMouseDown()
    {
        if (sm.GameisStarted)
        {
            this.gameObject.GetComponent<AudioSource>().Play();

            gp.AnyColorItem -= 1;
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("action");

            ButtonSkills();
            Ball.AnyColorWaiting = true;

        }
    }
}
