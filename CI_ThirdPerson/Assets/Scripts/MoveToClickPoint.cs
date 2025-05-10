// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
//    ClicksManager clicksManager;

    void Start()
    {
        Cursor.visible = true;
        agent = GetComponent<NavMeshAgent>();
 //       clicksManager = GameObject.Find("_GameManager").GetComponent<ClicksManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //clicksManager.IncreaseClicks();
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}