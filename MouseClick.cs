using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
     public Movement movement;
    // public GameObject farmer;
    public GameObject boat;
    // public GameObject wolf;
    // public GameObject cabbage;
    // public GameObject sheep;

    private void HandleObjectClick()
    {
            Debug.Log("Handling object click.");
            movement.MoveToBoat();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                GameObject clicked = hit.collider.gameObject;
                if (clicked == gameObject && clicked != boat)
                {
                    HandleObjectClick();
                }
                if (clicked == boat)
                {
                    movement.MoveBoat();
                }
            }
            
        }
    }

   
}
