using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameTimer : MonoBehaviour
{
    public float elapsedTime;
    public int active;
    // Start is called before the first frame update
    void Start()
    {
        if (active == 0)
        {
            elapsedTime = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active == 1)
        {
            elapsedTime += Time.deltaTime;
        }
    }
}
