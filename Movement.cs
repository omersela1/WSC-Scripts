using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    public GameObject boat;
    private BoatAvailability _boatAvailability;
    public float moveSpeed = 5f;
    public void MoveToBoat()
    {
        Debug.Log("Entered MoveToBoat().");
        if (CheckBoatAvailability())
        {
            Debug.Log("Moving to boat: " + gameObject.name);
            Vector3 target = boat.transform.position;
            target.y += 1;
            transform.position = target;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0f, 50f * moveSpeed));
            _boatAvailability.ChangeAvailability(gameObject);
        }
        else
        {
            Debug.Log("Boat not available.");
            MoveOffBoat();
        }
    }

    public bool CheckBoatAvailability()
    {
        return _boatAvailability.GetState();
    }

    public void MoveBoat()
    {
        GameObject validator = GameObject.Find("validator");
        Validator val = validator.GetComponent<Validator>();
        if (val.CheckValidity())
        {
            Rigidbody2D rb = boat.GetComponent<Rigidbody2D>();
            if (boat.transform.position.x < -0.5f && boat.transform.position.x > -1f)
                rb.AddForce(new Vector3(20f * moveSpeed, 0f, 0f));
            else
            {
                rb.AddForce(new Vector3(-20f * moveSpeed, 0f, 0f));
            }
        }
        else
        {
            if (CheckBoatAvailability())
            {
                GameLost();
            }
        }
    }


    public void MoveOffBoat()
    {
        Debug.Log("Entered MoveOffBoat().");
        if (_boatAvailability.currentObjectName == gameObject.name)
        {
            GameObject posBank = GameObject.Find("PositionBank");
            PositionBank positionBank = posBank.GetComponent<PositionBank>();
            Vector3 target = positionBank.GetPosition(gameObject.name);
            if (boat.transform.position.x < 0)
            {
                target.x -= 14.5f;
            }
            transform.position = target;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0f, 50f * moveSpeed));
            _boatAvailability.ChangeAvailability(null);
            Debug.Log("Changed availability.");
            
            GameObject validator = GameObject.Find("validator");
            Validator val = validator.GetComponent<Validator>();
            if (val.CheckValidity())
            {
                val.moveCount++;
                Debug.Log("Move count: " + val.moveCount);
            }
            else
            {
                GameLost();
                
            }
            
        }
    }

    public void GameLost()
    {
        GameObject uiHandler = GameObject.Find("UIObjectHandler");
        UIObjectHandler bank = uiHandler.GetComponent<UIObjectHandler>();
        bank.gameOverUI.SetActive(true);
        GameObject validator = GameObject.Find("validator");
        Validator val = validator.GetComponent<Validator>();
        val.GameOver = -1;
        GameObject ce = GameObject.Find("ClickEnabler");
        ClickEnabler e = ce.GetComponent<ClickEnabler>();
        e.enabler = false;
        Debug.Log("Game over.");
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        _boatAvailability = BoatAvailability.Instance();
    }
    

    // Update is called once per frame
    void Update()
    {
       
    }
}
