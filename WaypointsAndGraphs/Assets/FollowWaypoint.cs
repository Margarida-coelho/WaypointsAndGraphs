using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

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
        currentNode = wps[currentWP];
    }

    public void GoToCity()
    {
        g.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        g.AStar(currentNode, wps[7]);
        currentWP = 0;
    }

    public void GoToCactus()
    {
        g.AStar(currentNode, wps[6]);
        currentWP = 0;
    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[2]);
        currentWP = 0;
    }

    public void GoToPump()
    {
        g.AStar(currentNode, wps[5]);
        currentWP = 0;
    }

    public void GoToPalmTrees()
    {
        g.AStar(currentNode, wps[3]);
        currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (g.pathList.Count == 0 || currentWP == g.pathList.Count)
            return;

        if (Vector3.Distance(g.pathList[currentWP].GetID().transform.position, this.transform.position) < accuracy)
        {
            currentNode = g.pathList[currentWP].GetID();
            currentWP++;
        }

        if (currentWP < g.pathList.Count)
        {
            goal = g.pathList[currentWP].GetID().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
