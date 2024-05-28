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

        if (validNodes.Count > 0)
        {
            float randomValue = Random.value;

            if (randomValue < 0.5f)
            {
                int selectedNodeIndex = Random.Range(0, validNodes.Count);
                return validNodes.Get(selectedNodeIndex);
            }
            else
            {
                return previousNode;
            }
        }

        return null;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            NodeController previousNode = player.GetCurrentNode();
            NodeController selectedNode = GetNextNode(previousNode);

            if (selectedNode != null)
            {
                player.SetCurrentNode(this);
                player.MoveToPosition(selectedNode.gameObject.transform.position);
                selectedNode.DecreaseNodeEnergy(player.energyDrainAmount);
            }
            
        }
    }

    public void DecreaseNodeEnergy(float amount)
    {
        nodeEnergy -= amount;

       
    }
}
