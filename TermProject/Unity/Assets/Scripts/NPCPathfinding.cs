using UnityEngine;
using UnityEngine.AI;

public class NPCPathfinding : MonoBehaviour
{
    public Transform player; // Reference to the Player

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Set the Player's position as the destination
            agent.SetDestination(player.position);
        }
    }
}
