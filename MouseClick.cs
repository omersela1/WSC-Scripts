using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public Movement movement;
    public GameObject boat;
    public int gameOver;
    public ClickEnabler _clickEnabler;

    private void HandleObjectClick()
    {
            Debug.Log("Handling object click.");
            movement.MoveToBoat();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject validator = GameObject.Find("validator");
        Validator v = validator.GetComponent<Validator>();
        gameOver = v.GameOver;
        GameObject ce = GameObject.Find("ClickEnabler");
        _clickEnabler = ce.GetComponent<ClickEnabler>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    GameObject clicked = hit.collider.gameObject;
                    if (clicked == gameObject && clicked != boat)
                    {
                        if (_clickEnabler.enabler == true)
                        {
                            HandleObjectClick();
                        }
                    }

                    if (clicked == boat)
                    {
                        movement.MoveBoat();
                    }
                }

            }
        
    }

   
}
