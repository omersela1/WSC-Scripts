using System.Collections;
using System.Collections.Generic;
// using UnityEditorInternal;
using UnityEngine;

public class PositionBank : MonoBehaviour
{
    private static PositionBank _instance;
    public Vector3 sheepPos, wolfPos, cabPos, farmPos;
    
    public static PositionBank Instance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<PositionBank>();
            if (_instance == null)
            {
                GameObject singleton = new GameObject("PositionBank");
                _instance = singleton.AddComponent<PositionBank>();
            }
    
        }
        return _instance;
    }

    public Vector3 GetPosition(string objectName)
    {
        if (objectName == "sheep")
            return sheepPos;
        if (objectName == "wolf")
            return wolfPos;
        if (objectName == "cabbage")
            return cabPos;
        if (objectName == "farmer")
            return farmPos;

        return Vector3.zero;
    }

    public void Reinitialize()
    {
        GameObject sheep = GameObject.Find("sheep");
        sheep.transform.position = sheepPos;
        GameObject wolf = GameObject.Find("wolf");
        wolf.transform.position = wolfPos;
        GameObject cabbage = GameObject.Find("cabbage");
        cabbage.transform.position = cabPos;
        GameObject farmer = GameObject.Find("farmer");
        farmer.transform.position = farmPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject sheep = GameObject.Find("sheep");
        sheepPos = sheep.transform.position;
        GameObject wolf = GameObject.Find("wolf");
        wolfPos = wolf.transform.position;
        GameObject cabbage = GameObject.Find("cabbage");
        cabPos = cabbage.transform.position;
        GameObject farmer = GameObject.Find("farmer");
        farmPos = farmer.transform.position;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
