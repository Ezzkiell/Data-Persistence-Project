using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textchange : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerName.text = "Your nickname: " + ManagerData.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
