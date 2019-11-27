using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGameButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartRoom");
    }
}
