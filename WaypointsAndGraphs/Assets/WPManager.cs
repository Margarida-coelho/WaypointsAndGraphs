using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum Direction
    {
        UNI,
        BI
    }

    public GameObject node1;
    public GameObject node2;
    public Direction direction;
}

public class WPManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();

    // Start is called before the first frame update
    void Start()
    {
        if(waypoints.Length > 0)
        {
            foreach(GameObject wp in waypoints) graph.AddNode(wp);

            foreach(Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.direction == Link.Direction.BI) graph.AddEdge(l.node2, l.node1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
