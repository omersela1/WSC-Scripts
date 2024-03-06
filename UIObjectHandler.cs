using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectHandler : MonoBehaviour
{
    public GameObject startGameUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    // Start is called before the first frame update
    void Start()
    {
        startGameUI = GameObject.Find("Canvas");
        gameOverUI = GameObject.Find("GameOverCanvas");
        gameWinUI = GameObject.Find("Game Win Canvas");
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
