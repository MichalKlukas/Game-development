using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject npcPrefab; // The NPC prefab
    public Transform player; // Reference to the Player
    public Vector3 spawnAreaMin; // Minimum boundary of the spawn area
    public Vector3 spawnAreaMax; // Maximum boundary of the spawn area
    public float spawnInterval = 2f; // Time between spawns
    public int maxObjects = 20; // Maximum number of objects to spawn
    private int objectCount = 0; // Tracks how many objects have been spawned
    public float minDistance = 2f; // Minimum distance between objects to avoid overlap

    private void Start()
    {
        InvokeRepeating("SpawnNPC", 0f, spawnInterval);
    }

    void SpawnNPC()
    {
        if (objectCount >= maxObjects) return;

        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Check if there's a collider already at the spawn position (OverlapSphere check)
        if (Physics.CheckSphere(spawnPosition, minDistance))
        {
            // If there's already a collider, skip this spawn attempt
            return;
        }

        // Instantiate the prefab at the random position
        GameObject npc = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);

        // Assign the Player reference to the NPC's pathfinding script
        NPCPathfinding pathfinding = npc.GetComponent<NPCPathfinding>();
        if (pathfinding != null)
        {
            pathfinding.player = player; // Set the Player as the target
        }

        objectCount++;
    }
}

