using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("NPC Settings")]
    public GameObject npcPrefab; // Prefab for NPC
    public int npcCount = 50;    // Total NPCs to spawn

    [Header("Map Boundaries")]
    public Vector3 minBounds;   // Minimum x, y, z for spawn
    public Vector3 maxBounds;   // Maximum x, y, z for spawn

    [Header("Key Settings")]
    public KeyCode spawnKey = KeyCode.Space; // Key to trigger spawn

    void Update()
    {
        // Check for key press to spawn NPCs
        if (Input.GetKeyDown(spawnKey))
        {
            SpawnNPCs();
        }
    }

    void SpawnNPCs()
    {
        for (int i = 0; i < npcCount; i++)
        {
            // Generate a random position within the map bounds
            Vector3 randomPosition = new Vector3(
                Random.Range(minBounds.x, maxBounds.x),
                Random.Range(minBounds.y, maxBounds.y),
                Random.Range(minBounds.z, maxBounds.z)
            );

            // Instantiate the NPC at the random position
            Instantiate(npcPrefab, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the map bounds in the Scene view for visualization
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((minBounds + maxBounds) / 2, maxBounds - minBounds);
    }
}
