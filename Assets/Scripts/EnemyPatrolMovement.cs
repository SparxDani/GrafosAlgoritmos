using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{
    private Vector2 targetPosition;
    public float movementSpeed = 5f;
    public float currentEnergy = 5f;
    public float energyDrainAmount = 1f;
    public float recoveryTime = 3f;
    public float detectionRadius = 5f; 
    public float gizmoRadius = 5f;
    private bool isResting = false;
    private NodeController currentNode;
    private Rigidbody2D rb;
    private Transform player;
    private bool playerDetected = false;
    private LineRenderer lineRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        SetupLineRenderer();
        if (currentNode == null && FindObjectsOfType<NodeController>().Length > 0)
        {
            currentNode = FindObjectsOfType<NodeController>()[0];
            //Debug.Log($"Player initialized at node: {currentNode.name}");
        }
    }

    private void FixedUpdate()
    {
        if (!isResting)
        {
            if (playerDetected)
            {
                targetPosition = player.position;
            }

            if (targetPosition != (Vector2)rb.position)
            {
                Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
                rb.MovePosition(newPosition);
            }
        }
    }

    public void MoveToPosition(Vector2 destination)
    {
        if (!isResting)
        {
            //Debug.Log($"Moving to position: {destination}");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            // Volver a la patrulla
            if (currentNode != null)
            {
                MoveToPosition(currentNode.transform.position);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }

    private void SetupLineRenderer()
    {
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = detectionRadius;

        int segments = 100;
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;

        float angle = 0f;
        for (int i = 0; i < segments + 1; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * gizmoRadius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * gizmoRadius;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += (360f / segments);
        }

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }
}
