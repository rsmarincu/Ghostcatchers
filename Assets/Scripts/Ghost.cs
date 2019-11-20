using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[CreateAssetMenu(fileName ="New Ghost", menuName ="Ghosts/New Ghost")]
public class Ghost : ScriptableObject
{
    [HideInInspector]
    public string ghostName;
    
    public Sprite icon = null;

    [HideInInspector]
    public bool good;

    [HideInInspector]
    public float angle;

    [HideInInspector]
    public float range;

    [HideInInspector]
    public string story_1;

    [HideInInspector]
    public string story_2;
    
    [HideInInspector]
    public string story_3;

    public TextAsset jsonFile;

    public void Load()
    {
        JsonUtility.FromJsonOverwrite(this.jsonFile.ToString(), this);
    }

    public void test(){

        Debug.Log(ghostName + story_1);
    }
}
