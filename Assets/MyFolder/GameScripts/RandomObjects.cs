using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjects : MonoBehaviour {

    public string whichObject;

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
    
}
