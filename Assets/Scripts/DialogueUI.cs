using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public DialoguePanel dialoguePanel;
    public IconPanel iconPanel;

    private DialogueManager dialogueManager;

    private Ghost ghost;

    void Start(){
        dialogueManager = DialogueManager.instance;
    }
    void Update()
    {
        try{

            ghost = dialogueManager.ghost;

            if (ghost.visible){
                iconPanel.SetIcon(ghost.icon);
                dialoguePanel.SetText(ghost.GetStory());
            }           
        }
        catch{

        }
    }
}
