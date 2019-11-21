using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePanel : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public void SetText(string dialogue){
        textMeshPro.text = dialogue;
    }

    
}
