using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSkill : MonoBehaviour {

    public SceneManager sm;
    public GameProperties gp;
    public float newSpeed;

    public Transform circleCoins;


    public void ButtonSkill()
    {
        if (sm.GameisStarted && gp.SlowItem >= 1)
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

            gp.SlowItem -= 1;
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("action");

            ButtonSkill();

            newSpeed = (Ball.BallSpeed - 0.75f) / 2;

            Ball.thisObject.parent.GetComponent<Animator>().speed = newSpeed+0.75f;

        }
    }

}
