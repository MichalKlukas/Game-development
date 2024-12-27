using System.Collections;
using UnityEngine;
using UnityEngine.AI; // Required for NavMesh updates

public class DisappearingObjects : MonoBehaviour
{
    [Tooltip("Time this object stays invisible")]
    public float disappearTime = 2f;

    [Tooltip("Time this object stays visible")]
    public float appearTime = 3f;

    private NavMeshObstacle navMeshObstacle;

    private void Start()
    {
        // Try to get the NavMeshObstacle component if it exists
        navMeshObstacle = GetComponent<NavMeshObstacle>();

        // Start the toggling process for this object
        StartCoroutine(ToggleVisibility());
    }

    private IEnumerator ToggleVisibility()
    {
        while (true)
        {
            // Make the object disappear
            SetObjectVisibility(false);
            yield return new WaitForSeconds(disappearTime);

            // Make the object reappear
            SetObjectVisibility(true);
            yield return new WaitForSeconds(appearTime);
        }
    }

    private void SetObjectVisibility(bool isVisible)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        Collider[] colliders = GetComponentsInChildren<Collider>();

        // Enable/disable renderers for visibility
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = isVisible;
        }

        // Enable/disable colliders for interaction
        foreach (Collider collider in colliders)
        {
            collider.enabled = isVisible;
        }

        // Handle NavMeshObstacle if present
        if (navMeshObstacle != null)
        {
            navMeshObstacle.enabled = isVisible; // Disable to make it disappear from the NavMesh
        }
    }
}
