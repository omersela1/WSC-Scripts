using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject uiLayer;
    public ClickEnabler _clickEnabler;
    public UIObjectHandler UIObjHandler;
    
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

    public void ShowHighscoresClick()
    {
        
    }

    public void MainMenuClick()
    {
        
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


