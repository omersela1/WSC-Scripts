using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Validator : MonoBehaviour
{
    public int GameOver;
    public Time StartTime;
    public Time EndTime;
    public int moveCount;

    public GameObject sheep, wolf, cabbage, boat, posBank;
    public PositionBank positions;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = new Time();
        GameOver = 0;
        moveCount = 0;
        
        sheep = GameObject.Find("sheep");
        wolf = GameObject.Find("wolf");
        cabbage = GameObject.Find("cabbage");
        boat = GameObject.Find("boat");
        posBank = GameObject.Find("PositionBank");
        positions = posBank.GetComponent<PositionBank>();
    }

    public bool CheckValidity()
    {
        Debug.Log("Checking validity.");
        Debug.Log("Sheep Pos: " + sheep.transform.position);
        Debug.Log("Wolf Pos: " + wolf.transform.position);
        Debug.Log("Cabbage Pos: " + cabbage.transform.position);
        Debug.Log("Sheep Bank Pos: " + positions.sheepPos);
        Debug.Log("Wolf Bank Pos: " + positions.wolfPos);
        Debug.Log("Cabbage Bank Pos: " + positions.cabPos);
        
        if (Math.Abs(sheep.transform.position.x - positions.sheepPos.x) < 0.5f)
        {
            if (Math.Abs(wolf.transform.position.x - positions.wolfPos.x) < 0.5f && Math.Abs(cabbage.transform.position.x - positions.cabPos.x) > 12f)
            {
                if (boat.transform.position.x < 0)
                {
                    return false;
                }
            }
            
            if (Math.Abs(wolf.transform.position.x - positions.wolfPos.x) > 12f && Math.Abs(cabbage.transform.position.x - positions.cabPos.x) < 0.5f)
            {
                if (boat.transform.position.x < 0)
                {
                    return false;
                }
            }
        }
        if (Math.Abs(sheep.transform.position.x - positions.sheepPos.x) > 12f)
        {
            if (Math.Abs(wolf.transform.position.x - positions.wolfPos.x) < 0.5f && Math.Abs(cabbage.transform.position.x - positions.cabPos.x) > 12f)
            {
                if (boat.transform.position.x > -0.5f)
                {
                    return false;
                }
            }

            if (Math.Abs(wolf.transform.position.x - positions.wolfPos.x) > 12f && Math.Abs(cabbage.transform.position.x - positions.cabPos.x) < 0.5f)
            {
                if (boat.transform.position.x > -0.5f)
                {
                    return false;
                }
            }

            if (Math.Abs(wolf.transform.position.x - positions.wolfPos.x) > 12f && Math.Abs(cabbage.transform.position.x - positions.cabPos.x) > 12f)
            {
                Movement move = sheep.GetComponent<Movement>();
                if (move.CheckBoatAvailability())
                {
                    GameWin();
                }
            }
        }
        Debug.Log("Move is valid.");
        return true;
    }

    public void GameWin()
    {
        Debug.Log("Game Won!");
        GameOver = 1;
        EndTime = new Time();
        GameObject handler = GameObject.Find("UIObjectHandler");
        GameObject winMenu = handler.GetComponent<UIObjectHandler>().gameWinUI;
        winMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
