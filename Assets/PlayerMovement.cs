using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 targetPosition;
    public float movementSpeed = 5f;
    public float currentEnergy = 5f;
    public float energyDrainAmount = 1f;
    public float recoveryTime = 3f;
    private bool isResting = false;
    private NodeController currentNode;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isResting)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }
    }

    public void MoveToPosition(Vector2 destination)
    {
        if (!isResting)
        {
            targetPosition = destination;
            DrainEnergy();
        }
    }

    private void DrainEnergy()
    {
        currentEnergy -= energyDrainAmount;

        if (currentEnergy <= 0)
        {
            StartCoroutine(Rest());
        }
    }

    private IEnumerator Rest()
    {
        isResting = true;
        yield return new WaitForSeconds(recoveryTime);
        currentEnergy = 5f;
        isResting = false;
    }

    public void SetCurrentNode(NodeController node)
    {
        currentNode = node;
    }

    public NodeController GetCurrentNode()
    {
        return currentNode;
    }
}
