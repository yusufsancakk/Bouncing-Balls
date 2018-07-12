using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3D : MonoBehaviour {

    public Transform open1;

    void OnMouseDown()
    {
        open1.gameObject.SetActive(true);
    }
}
