using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    public GameObject boat;
    private BoatAvailability ba;
    public float moveSpeed = 5f;
    public void MoveToBoat()
    {
        if (CheckBoatAvailability())
        {
            Debug.Log("Moving to boat: " + gameObject.name);
            Vector3 target = boat.transform.position;
            target.y += 1;
            transform.position = target;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0f, 50f * moveSpeed));
            ba.ChangeAvailability(gameObject);
        }
        else
        {
            Debug.Log("Boat not available.");
            MoveOffBoat();
        }
    }

    public bool CheckBoatAvailability()
    {
        return ba.GetState();
    }

    public void MoveBoat()
    {
        Rigidbody2D rb = boat.GetComponent<Rigidbody2D>();
        if (boat.transform.position.x < -0.5f && boat.transform.position.x > -1f)
            rb.AddForce(new Vector3(20f * moveSpeed,0f,0f));
        else
        {
            rb.AddForce(new Vector3(-20f * moveSpeed,0f,0f));
        }
    }


    public void MoveOffBoat()
    {
        Debug.Log("Entered MoveOffBoat().");
        if (ba.currentObjectName == gameObject.name)
        {
            Vector3 target = new Vector3(0f,0f,-4f);
            if (boat.transform.position.x < 0)
            {
                target.x = -7.47f;
            }
            else
            {
                target.x = 4.8f;
            }
            transform.position = target;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0f, 50f * moveSpeed));
            ba.ChangeAvailability(null);
            Debug.Log("Changed availability.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ba = BoatAvailability.Instance();
    }
    

    // Update is called once per frame
    void Update()
    {
       
    }
}
