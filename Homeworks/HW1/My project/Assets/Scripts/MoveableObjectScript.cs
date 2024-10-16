using UnityEngine;

public class MoveableObjectScript : MonoBehaviour
{
    public Rigidbody rb; // Public variable to assign the Rigidbody component in Unity Editor
    public Vector3 force = new Vector3(0, 0, 10); // Define the amount and direction of force

    void Start()
    {
        // Check if Rigidbody is assigned, otherwise try to get it automatically
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        // Add a continuous force to the Rigidbody every frame
        if (rb != null)
        {
            rb.AddForce(force);
        }
    }
}
