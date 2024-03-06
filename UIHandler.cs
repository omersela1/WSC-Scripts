using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject uiLayer;
    private ClickEnabler _clickEnabler;
    
    public void StartGameClick()
    {
        _clickEnabler.enabler = true;
        uiLayer.SetActive(false);
        PositionBank pb = GameObject.Find("PositionBank").GetComponent<PositionBank>();
        pb.Reinitialize();

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
