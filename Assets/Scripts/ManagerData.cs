using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ManagerData : MonoBehaviour
{
    public static ManagerData Instance;
    public TMP_InputField PlayerNameField;
    public string playerName = "";
    public int BestPlayerScore;
    public MainManager mainManager;
    public int newScore;
    public string bestScoreString;
    public int top1Score;



    private void Start()
    {
        

    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
       
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    private void Update()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    public void SetBestScore()
    {
        
        
        if (BestPlayerScore > newScore)
        {
            newScore = BestPlayerScore;
        }

        if (newScore > top1Score) {
            top1Score = newScore;
        }

        if (newScore >= top1Score)
        {
            mainManager.BestScoreHolder.text = "Best Score : " + playerName + " : " + top1Score;
            bestScoreString = mainManager.BestScoreHolder.text;
            SaveScore();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string bestScoreString;
        public int top1Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScoreString = bestScoreString;
        data.top1Score = top1Score;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreString = data.bestScoreString;
            top1Score = data.top1Score;
        }
    }

}
