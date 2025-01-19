using UnityEngine;

[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{
    [Tooltip("Maximum distance from the ground.")]
    public float distanceThreshold = 0.15f;

    [Tooltip("Angle of the raycast in degrees.")]
    [Range(0, 45)] // Ограничиваем угол для удобства.
    public float raycastAngle = 0f;

    [Tooltip("Whether this transform is grounded now.")]
    public bool isGrounded = true;

    /// <summary>
    /// Called when the ground is touched again.
    /// </summary>
    public event System.Action Grounded;

    const float OriginOffset = 0.001f;
    Vector3 RaycastOrigin => transform.position + Vector3.up * OriginOffset;
    float RaycastDistance => distanceThreshold + OriginOffset;

    void LateUpdate()
    {
        // Вычисляем направление с учетом угла.
        Vector3 rayDirection = Quaternion.Euler(raycastAngle, 0, 0) * Vector3.down;

        // Проверяем, касается ли объект земли.
        bool isGroundedNow = Physics.Raycast(RaycastOrigin, rayDirection, RaycastDistance);

        // Вызываем событие, если объект только что приземлился.
        if (isGroundedNow && !isGrounded)
        {
            Grounded?.Invoke();
        }

        // Обновляем состояние isGrounded.
        isGrounded = isGroundedNow;
    }

    void OnDrawGizmosSelected()
    {
        // Вычисляем направление с учетом угла.
        Vector3 rayDirection = Quaternion.Euler(raycastAngle, 0, 0) * Vector3.down;

        // Отображаем линию для визуализации рейкаста.
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(RaycastOrigin, RaycastOrigin + rayDirection * RaycastDistance);
    }
}
