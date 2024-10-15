using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Reference to the prefab

    void Update()
    {
        // Check if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Spawn the prefab at the current object's position and rotation
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
}