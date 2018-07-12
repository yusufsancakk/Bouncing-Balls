using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketButton : MonoBehaviour {

    public Transform open1;
    public Transform close1;
    public ShoppingManager spma;

    void OnMouseDown()
    {
        this.gameObject.GetComponent<AudioSource>().Play();

        spma.Started();
        open1.gameObject.SetActive(true);
        close1.gameObject.SetActive(false);
    }

  
}
