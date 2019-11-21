using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[CreateAssetMenu(fileName ="New Ghost", menuName ="Scriptable Objects/New Ghost")]
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

    public int index;

    public bool visible;

    public bool waiting;

    public void Load()
    {
        JsonUtility.FromJsonOverwrite(this.jsonFile.ToString(), this);
    }

    public string GetStory(){




        List<string> stories = new List<string>();
        stories.Add(story_1);
        stories.Add(story_2);
        stories.Add(story_3);
        stories.Add("");

        if(waiting){
            return stories[index % 3];
        }
        else{
            return stories[3];
        }
        
    }
}
