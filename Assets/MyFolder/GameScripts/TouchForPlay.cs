using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchForPlay : MonoBehaviour {

    public SceneManager sm;
    public Transform close1;
    public Transform open1;
    public AudioSource audio;

    void OnMouseDown()
    {
        close1.gameObject.SetActive(false);
        open1.gameObject.SetActive(true);
        audio.Play();
        sm.GameStart();
    }

}
