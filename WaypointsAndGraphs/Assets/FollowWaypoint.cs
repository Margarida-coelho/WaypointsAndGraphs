using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    Transform goal;

    float speed = 10.0f;
    float accuracy = 2.0f;
    float rotSpeed = 4.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
        GoToHeli();
    }


    public void GoToHeli()
    {
        g.AStar(currentNode, wps[2]);
        currentWP = 0;
    }
}
