using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour
{
    public int GameOver;
    public Time StartTime;
    public Time EndTime;
    public int moveCount;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = new Time();
        GameOver = 0;
        moveCount = 0;
    }

    public bool CheckValidity()
    {
        Debug.Log("Checking validity.");
        GameObject sheep = GameObject.Find("sheep");
        GameObject wolf = GameObject.Find("wolf");
        GameObject cabbage = GameObject.Find("cabbage");
        GameObject posBank = GameObject.Find("PositionBank");
        PositionBank positions = posBank.GetComponent<PositionBank>();

        if (sheep.transform.position == positions.sheepPos)
        {
            if (wolf.transform.position == positions.wolfPos && cabbage.transform.position != positions.cabPos)
                return false;
            if (wolf.transform.position != positions.wolfPos && cabbage.transform.position == positions.cabPos)
                return false;
        }
        if (sheep.transform.position != positions.sheepPos)
        {
            if (wolf.transform.position == positions.wolfPos && cabbage.transform.position != positions.cabPos)
                return false;
            if (wolf.transform.position != positions.wolfPos && cabbage.transform.position == positions.cabPos)
                return false;
            if (wolf.transform.position != positions.wolfPos && cabbage.transform.position != positions.cabPos)
                GameOver = 1;
        }
        Debug.Log("Move is valid.");
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
