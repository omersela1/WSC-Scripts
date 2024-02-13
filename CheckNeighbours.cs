// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
//
// public class CheckNeighbours : MonoBehaviour
// {
//     public static GameObject sheep;
//     public static GameObject wolf;
//     public static GameObject cabbage;
//     private float _sheepPos = sheep.transform.position.x;
//     private float _wolfPos = wolf.transform.position.x;
//     private float _cabPos = cabbage.transform.position.x;
//     
//     public bool CheckValidity()
//     {
//         if (Movement.ba.GetState())
//         {
//             if ((Mathf.Abs(sheep.transform.position.x - wolf.transform.position.x) < 2)
//                 && (Mathf.Abs(sheep.transform.position.x - cabbage.transform.position.x) > 4))
//             {
//                 return false;
//             }
//
//             if ((Mathf.Abs(sheep.transform.position.x - cabbage.transform.position.x) < 2)
//                 && (Mathf.Abs(sheep.transform.position.x - wolf.transform.position.x) > 4))
//             {
//                 return false;
//             }
//         }
//
//         return true;
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         if (!(CheckValidity()))
//         {
//             sheep.transform.position = new Vector3(_sheepPos, 0f, -4f);
//             wolf.transform.position = new Vector3(_wolfPos, 0f, -4f);
//             cabbage.transform.position = new Vector3(_cabPos, 0f, -4f);
//
//         }
//     }
// }
