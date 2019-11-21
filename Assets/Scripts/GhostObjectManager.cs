using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObjectManager : MonoBehaviour
{
    public static GhostObjectManager instance;
    public List<Ghost> ghostList = new List<Ghost>();

    private int length;

    private List<int> randomIndexes = new List<int>();

    public delegate void OnEvent();

    public OnEvent OnEventCallback;

    private int r;

    private void Awake(){

        if (instance != null){
            return;
        }

        instance = this;

        length = ghostList.Count;

        for (int i=0; i<length; i++){
            r = Random.Range(0,length);
            while (randomIndexes.Contains(r)){
                r = Random.Range(0,length);
            }
            randomIndexes.Add(r);
        }

    }


    public Ghost getGhost(int index){
       
        int randomIndex = randomIndexes[index];


        if(OnEventCallback != null)
        {
            OnEventCallback.Invoke();
        }

        return ghostList[randomIndex];
    }

}
