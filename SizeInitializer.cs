using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SizeInitializer : MonoBehaviour
    {
        public bool isVisible;
        public GameObject sheep;
        public GameObject wolf;
        public GameObject cabbage;
        public GameObject farmer;
        public GameObject boat;

        public void InitializeAll()
        {
            
            // Check if the GameObjects are found before accessing components
            if (sheep != null)
                sheep.GetComponent<SpriteRenderer>().size = new Vector2(0.2f, 0.2f);

            if (wolf != null)
                wolf.GetComponent<SpriteRenderer>().size = new Vector2(0.2f, 0.2f);

            if (cabbage != null)
                cabbage.GetComponent<SpriteRenderer>().size = new Vector2(0.2f, 0.2f);

            if (farmer != null)
                farmer.GetComponent<SpriteRenderer>().size = new Vector2(0.2f, 0.4f);

            if (boat != null)
                boat.GetComponent<SpriteRenderer>().size = new Vector2(0.5f, 0.25f);
        }

        public void SetInvisible()
        {
            sheep.SetActive(false);
            wolf.SetActive(false);
            cabbage.SetActive(false);
            farmer.SetActive(false);
            boat.SetActive(false);

            isVisible = false;

        }
        
        public void SetVisible()
        {
            sheep.SetActive(true);
            wolf.SetActive(true);
            cabbage.SetActive(true);
            farmer.SetActive(true);
            boat.SetActive(true);
            InitializeAll();

            isVisible = true;

        }
        // Start is called before the first frame update
        void Start()
        { 
            sheep = GameObject.Find("sheep"); 
            wolf = GameObject.Find("wolf");
            cabbage = GameObject.Find("cabbage");
            farmer = GameObject.Find("farmer");
            boat = GameObject.Find("boat");
            
        }

      

        // Update is called once per frame
        void Update()
        {
            // Update logic here if needed
        }
    }