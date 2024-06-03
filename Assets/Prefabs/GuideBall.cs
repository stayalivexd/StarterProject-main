using UnityEngine;

public class GuideBall : MonoBehaviour
{
    public Transform[] positions; // Array of positions that the ball can move to
    public float speed = 1.0f;

    private Vector3 targetPosition;

    void Start()
    {
        // Set the initial target position to the ball's current position
        targetPosition = transform.position;
    }

    void Update()
    {
        // Move the ball towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }

    public void MoveToPosition(int index)
    {
        // Set the target position to the position at the given index
        if (index >= 0 && index < positions.Length)
        {
            targetPosition = positions[index].position;
        }
    }
}
