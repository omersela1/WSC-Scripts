using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIObjectHandler : MonoBehaviour
{
    public GameObject startGameUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public GameObject highscoresUI;
    public GameObject timer;

    public void DeactivateAll()
    {
        startGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        highscoresUI.SetActive(false);
    }

    public void ActivateHighscores()
    {
        highscoresUI.SetActive(true);
    }
    

    public void ReturnToMainMenu()
    {
        DeactivateAll();
        startGameUI.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        DeactivateAll();
        startGameUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
