using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (!Directory.Exists(Application.persistentDataPath + "/Data")) 
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Data");
            File.Create(Application.persistentDataPath + "/Data/Coins.txt");
            File.Create(Application.persistentDataPath + "/Data/SlowSkills.txt");
            File.Create(Application.persistentDataPath + "/Data/AnyColorSkills.txt");
            File.Create(Application.persistentDataPath + "/Data/MissionID.txt");

        }

    }
	
	
}
