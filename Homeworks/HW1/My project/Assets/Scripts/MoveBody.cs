using UnityEngine;

public class MoveBody : MonoBehaviour
{
    public float forceAmount = 10f; // The force applied to the object

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Initialize a Vector3 for movement
        Vector3 movement = Vector3.zero;

        // Check for inputs and set the movement direction
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            movement += Vector3.forward;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            movement += Vector3.back;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            movement += Vector3.left;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            movement += Vector3.right;

        // Apply the movement as a force to the Rigidbody
        rb.AddForce(movement * forceAmount);
    }
}
