using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public void startGame(string screenName)
    {
        Debug.Log(string.Format("Moving to scene: {0}", screenName));
        SceneManager.LoadScene(screenName);
    }
}
