using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject uiLayer;
    public ClickEnabler _clickEnabler;
    public UIObjectHandler UIObjHandler;
    public HTTPHandler HttpHandler;
    
    public void StartGameClick()
    {
        
        _clickEnabler.enabler = true;
        GameTimer timer = UIObjHandler.timer.GetComponent<GameTimer>();
        if (timer == null)
        {
            Debug.Log("Timer object not found.");
        }
        else
        {
            timer.elapsedTime = 0.0f;
            timer.active = 1;
        }

        PositionBank pb = GameObject.Find("PositionBank").GetComponent<PositionBank>();
        pb.Reinitialize();
        uiLayer.SetActive(false);

    }

    public async void ShowHighscoresClick()
    {
        UIObjHandler.ActivateHighscores();
        Debug.Log("Getting highscores...");
        var results = await HttpHandler.GetFormattedTopResultsAsync("http://localhost:3000/api/Results/top");
        UIObjHandler.Result1.text = results[0];
        UIObjHandler.Result2.text = results[1];
        UIObjHandler.Result3.text = results[2];
        UIObjHandler.Result4.text = results[3];
        UIObjHandler.Result5.text = results[4];

    }

    public void MainMenuClick()
    {
        UIObjHandler.ReturnToMainMenu();
        
    }

    public void QuitGameClick()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject ce = GameObject.Find("ClickEnabler");
        _clickEnabler = ce.GetComponent<ClickEnabler>();
        HttpHandler = GameObject.Find("HTTPHandler").GetComponent<HTTPHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


