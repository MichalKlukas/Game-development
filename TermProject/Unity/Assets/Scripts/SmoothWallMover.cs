using UnityEngine;
using System.Collections;
public class SmoothWallMover : MonoBehaviour
{
    public Vector3[] positions; // Array of positions for the wall to move to
    public float moveDuration = 3f; // Time (in seconds) it takes to move to the next position
    public float interval = 10f;   // Time between moves
    private int currentTargetIndex = 0; // Index of the next target position


    void Start()
    {
        if (positions.Length > 0)
        {
            StartCoroutine(MoveWallAtIntervals());
        }
        else
        {
            Debug.LogError("No positions assigned to the wall. Please add target positions in the Inspector.");
        }
    }

    private IEnumerator MoveWallAtIntervals()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval); // Wait before moving

            // Start moving the wall
            StartCoroutine(SmoothMove(transform.position, positions[currentTargetIndex], moveDuration));

            // Update the target index
            currentTargetIndex = (currentTargetIndex + 1) % positions.Length;
        }
    }

    private IEnumerator SmoothMove(Vector3 start, Vector3 end, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = end; // Ensure the wall reaches the exact final position
    }
}
