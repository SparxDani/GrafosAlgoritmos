using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController: MonoBehaviour
{
    public CustomList<NodeController> listOfNodes;
    public NodeController actualNode;
    public PlayerMovement playerMovement;
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

        playerMovement.MoveToPosition(actualNode.gameObject.transform.position);
        playerMovement.SetCurrentNode(actualNode);

    }
}
