using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IconPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Image icon;

    public void SetIcon(Sprite currentIcon){
        icon.sprite = currentIcon;
    }
    
}
