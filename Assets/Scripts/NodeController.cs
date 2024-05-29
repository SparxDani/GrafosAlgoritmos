using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public NodeController[] adyNodes;
    public float nodeEnergy = 5f;

    public NodeController GetNextNode(NodeController previousNode)
    {
        CustomList<NodeController> validNodes = new CustomList<NodeController>();

        for (int i = 0; i < adyNodes.Length; i++)
        {
            NodeController node = adyNodes[i];
            if (node != previousNode)
            {
                validNodes.Add(node);
            }
        }

        //Debug.Log($"Valid nodes count: {validNodes.Count}");

        if (validNodes.Count > 0)
        {
            int selectedNodeIndex = Random.Range(0, validNodes.Count);
            NodeController selectedNode = validNodes.Get(selectedNodeIndex);
            //Debug.Log($"Selected Node: {selectedNode.name} at index: {selectedNodeIndex}");
            return selectedNode;
        }

        return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyPatrolMovement player = other.GetComponent<EnemyPatrolMovement>();
            NodeController previousNode = player.GetCurrentNode();
            NodeController selectedNode = GetNextNode(previousNode);

            if (selectedNode != null && selectedNode != this)
            {
                //Debug.Log($"Player moved to node: {selectedNode.name}");
                player.SetCurrentNode(selectedNode);
                player.MoveToPosition(selectedNode.gameObject.transform.position);
                selectedNode.DecreaseNodeEnergy(player.energyDrainAmount);
            }
            /*else
            {
                Debug.Log("Selected node is null or the same as the current node");
            }*/
        }
    }



    public void DecreaseNodeEnergy(float amount)
    {
        nodeEnergy -= amount;
    }
}
