using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void Update()
    {
        
    }
    public void StartGame()
    {
        ManagerData.Instance.playerName = ManagerData.Instance.PlayerNameField.text;
        SceneManager.LoadScene(1);
        ManagerData.Instance.mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

}
