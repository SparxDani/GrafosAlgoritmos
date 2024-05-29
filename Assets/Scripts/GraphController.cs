using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController: MonoBehaviour
{
    public CustomList<NodeController> listOfNodes;
    public NodeController actualNode;
    public EnemyPatrolMovement playerMovement;
    void Start()
    {
        listOfNodes = new CustomList<NodeController>();

        GameObject nodeObject1 = GameObject.Find("Node (1)");
        NodeController node1 = nodeObject1.GetComponent<NodeController>();
        if (node1 != null)
        {
            listOfNodes.Add(node1);
        }

        GameObject nodeObject2 = GameObject.Find("Node (2)");
        NodeController node2 = nodeObject2.GetComponent<NodeController>();
        if (node2 != null)
        {
            listOfNodes.Add(node2);
        }

        GameObject nodeObject3 = GameObject.Find("Node (3)");
        NodeController node3 = nodeObject3.GetComponent<NodeController>();
        if (node3 != null)
        {
            listOfNodes.Add(node3);
        }

        GameObject nodeObject4 = GameObject.Find("Node (4)");
        NodeController node4 = nodeObject4.GetComponent<NodeController>();
        if (node4 != null)
        {
            listOfNodes.Add(node4);
        }

        GameObject nodeObject5 = GameObject.Find("Node (5)");
        NodeController node5 = nodeObject5.GetComponent<NodeController>();
        if (node5 != null)
        {
            listOfNodes.Add(node5);
        }

        GameObject nodeObject6 = GameObject.Find("Node (6)");
        NodeController node6 = nodeObject6.GetComponent<NodeController>();
        if (node6 != null)
        {
            listOfNodes.Add(node6);
        }

        GameObject nodeObject7 = GameObject.Find("Node (7)");
        NodeController node7 = nodeObject7.GetComponent<NodeController>();
        if (node7 != null)
        {
            listOfNodes.Add(node7);
        }

        GameObject nodeObject8 = GameObject.Find("Node (8)");
        NodeController node8 = nodeObject8.GetComponent<NodeController>();
        if (node8 != null)
        {
            listOfNodes.Add(node8);
        }

        GameObject nodeObject9 = GameObject.Find("Node (9)");
        NodeController node9 = nodeObject8.GetComponent<NodeController>();
        if (node9 != null)
        {
            listOfNodes.Add(node9);
        }

        GameObject nodeObject10 = GameObject.Find("Node (10)");
        NodeController node10 = nodeObject8.GetComponent<NodeController>();
        if (node10 != null)
        {
            listOfNodes.Add(node10);
        }

        GameObject nodeObject11 = GameObject.Find("Node (11)");
        NodeController node11 = nodeObject8.GetComponent<NodeController>();
        if (node11 != null)
        {
            listOfNodes.Add(node11);
        }

        GameObject nodeObject12 = GameObject.Find("Node (12)");
        NodeController node12 = nodeObject8.GetComponent<NodeController>();
        if (node12 != null)
        {
            listOfNodes.Add(node12);
        }

        GameObject nodeObject13 = GameObject.Find("Node (13)");
        NodeController node13 = nodeObject8.GetComponent<NodeController>();
        if (node13 != null)
        {
            listOfNodes.Add(node13);
        }

        GameObject nodeObject14 = GameObject.Find("Node (14)");
        NodeController node14 = nodeObject8.GetComponent<NodeController>();
        if (node14 != null)
        {
            listOfNodes.Add(node14);
        }

        GameObject nodeObject15 = GameObject.Find("Node (15)");
        NodeController node15 = nodeObject8.GetComponent<NodeController>();
        if (node15 != null)
        {
            listOfNodes.Add(node15);
        }

        GameObject nodeObject16 = GameObject.Find("Node (16)");
        NodeController node16 = nodeObject8.GetComponent<NodeController>();
        if (node16 != null)
        {
            listOfNodes.Add(node16);
        }
        playerMovement.MoveToPosition(actualNode.gameObject.transform.position);
        playerMovement.SetCurrentNode(actualNode);

    }
}
