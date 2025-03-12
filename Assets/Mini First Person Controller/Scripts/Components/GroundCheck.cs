using UnityEngine;

[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{
    [Tooltip("Whether this transform is grounded now.")]
    public bool isGrounded = true;

    [Tooltip("Offset from the object to start the raycast.")]
    public float raycastOffset = 0.1f;

    [Tooltip("Raycast distance to check for the ground.")]
    public float raycastDistance = 0.2f;

    [Tooltip("Layers considered as ground.")]
    public LayerMask groundLayer;

    /// <summary>
    /// Called when the ground is touched again.
    /// </summary>
    public event System.Action Grounded;

    void Update()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics.Raycast(transform.position + Vector3.up * raycastOffset, Vector3.down, raycastDistance, groundLayer);

        if (!wasGrounded && isGrounded)
        {
            Grounded?.Invoke();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position + Vector3.up * raycastOffset, transform.position + Vector3.up * raycastOffset + Vector3.down * raycastDistance);
    }
}