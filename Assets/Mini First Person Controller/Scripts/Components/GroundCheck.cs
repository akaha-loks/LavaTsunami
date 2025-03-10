    using UnityEngine;

    [ExecuteInEditMode]
    public class GroundCheck : MonoBehaviour
    {
        [Tooltip("Whether this transform is grounded now.")]
        public bool isGrounded = true;

        /// <summary>
        /// Called when the ground is touched again.
        /// </summary>
        public event System.Action Grounded;

    void OnTriggerEnter(Collider other)
    {
        if (!isGrounded)
        {
            isGrounded = true;
            Grounded?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
