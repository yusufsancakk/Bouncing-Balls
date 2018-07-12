using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour {

    public Ball ball;
    public SceneManager sm;
    public Transform shadowBall;

    void OnMouseDown()
    {
        if (sm.GameisStarted)
        {
            shadowBall.gameObject.SetActive(false);
            ball.gameObject.transform.GetComponent<Animator>().SetTrigger("zipzip");
            ball.StopBall = true;
        }
    }

}
