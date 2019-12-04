using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialScene : MonoBehaviour
{
    public void startTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
