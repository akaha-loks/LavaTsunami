using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    [Header("Animation")]
    public Animator anim;
    public float timeToEnd = 0.2f;

    private bool isHitting = false; // Флаг для отслеживания анимации удара

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Запуск анимации удара, если она не выполняется
        if (Input.GetMouseButton(0) && !isHitting)
        {
            StartCoroutine(PlayHitAnimation());
        }

        UpdateMovementAnimation();

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
        if (transform.position.y < -15)
        {
            Die();
        }
    }

    private IEnumerator PlayHitAnimation()
    {
        isHitting = true; // Устанавливаем флаг, что анимация запущена
        anim.SetBool("Hit", true);
        yield return new WaitForSeconds(timeToEnd); // Ждём завершения текущей анимации
        anim.SetBool("Hit", false);
        isHitting = false; // Сбрасываем флаг
    }

    private void UpdateMovementAnimation()
    {
        bool isMoving = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        anim.SetBool("Run", isMoving);
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lava"))
        {
            Die();
        }
    }
}
