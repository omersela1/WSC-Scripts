using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAvailability : MonoBehaviour
{
    private static BoatAvailability _instance;
    public string currentObjectName;
    public static bool Availability { get; private set; } = true;

    public static BoatAvailability Instance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<BoatAvailability>();
            if (_instance == null)
            {
                GameObject singleton = new GameObject("BoatAvailability");
                _instance = singleton.AddComponent<BoatAvailability>();
            }
    
        }
        return _instance;
    }
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool GetState()
    {
        return Availability;
    }

    public void ChangeAvailability(GameObject movedObject)
    {
        if (Availability == true)
        {
            Availability = false;
            currentObjectName = movedObject != null ? movedObject.name : null;
            Debug.Log("Boat availability changed by: " + movedObject.name);
        }
        else
        {
            Availability = true;
            currentObjectName = null;
            Debug.Log("Boat is available.");
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
