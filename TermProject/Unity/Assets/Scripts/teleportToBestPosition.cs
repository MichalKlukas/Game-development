using UnityEngine;
using System.Collections;

public class teleportToBestPosition : MonoBehaviour
{
    private Vector3 mapMin = new Vector3(-14, 0.55f, -14); // Minimum boundary of the map
    private Vector3 mapMax = new Vector3(14, 0.55f, 14);   // Maximum boundary of the map
    public float checkRadius = 2f; // Radius to check for NPC density
    public float teleportInterval = 5f; // Time interval for teleporting
    public LayerMask npcLayer; // Layer for NPC objects to count them
    public int randomSamples = 500; // Number of random points to sample

    private void Start()
    {
        Debug.Log($"Hardcoded map boundaries: mapMin = {mapMin}, mapMax = {mapMax}");
        StartCoroutine(TeleportPeriodically());
    }

    IEnumerator TeleportPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);
            TeleportToBestPosition();
        }
    }

    void TeleportToBestPosition()
    {
        Debug.Log($"TeleportToBestPosition called at {Time.time}");

        Vector3 bestPosition = transform.position; // Default to current position
        int lowestDensity = int.MaxValue; // Reset density for each teleport

        Debug.Log($"Map boundaries: mapMin = {mapMin}, mapMax = {mapMax}");

        for (int i = 0; i < randomSamples; i++)
        {
            // Generate a new random position
            Vector3 randomPosition = new Vector3(
                Random.Range(mapMin.x, mapMax.x),
                Random.Range(mapMin.y, mapMax.y),
                Random.Range(mapMin.z, mapMax.z)
            );

            Debug.Log($"Generated random position: {randomPosition}");

            // Check for NPC density at this position
            Collider[] nearbyNPCs = Physics.OverlapSphere(randomPosition, checkRadius, npcLayer);
            int density = nearbyNPCs.Length;

            Debug.Log($"Testing position {randomPosition}, Density: {density}");

            // Update the best position if the density is lower
            if (density < lowestDensity)
            {
                lowestDensity = density;
                bestPosition = randomPosition;
            }
        }

        if (lowestDensity == int.MaxValue)
        {
            Debug.LogWarning("No valid teleport positions found! Fallback to random position.");
            bestPosition = new Vector3(
                Random.Range(mapMin.x, mapMax.x),
                Random.Range(mapMin.y, mapMax.y),
                Random.Range(mapMin.z, mapMax.z)
            );
        }

        // Teleport the player to the new best position
        transform.position = bestPosition;
        Debug.Log($"Teleported to: {bestPosition}, Density: {lowestDensity}");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube((mapMin + mapMax) / 2, mapMax - mapMin);
    }
}
