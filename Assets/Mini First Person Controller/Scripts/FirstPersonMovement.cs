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

    private Jump jump;

    private bool isHitting = false; // Флаг для отслеживания анимации удара

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    [SerializeField] private PlayerDeath die;

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        jump = GetComponent<Jump>();
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            LoaderScenes.RessetSaves();
        }

        UpdateMovementAnimation();

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Получаем направление движения
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Если есть движение, нормализуем направление
        if (inputDirection.magnitude > 1)
        {
            inputDirection.Normalize();
        }

        // Применяем движение
        Vector3 moveDirection = transform.rotation * new Vector3(inputDirection.x, 0, inputDirection.y) * targetMovingSpeed;
        rigidbody.velocity = new Vector3(moveDirection.x, rigidbody.velocity.y, moveDirection.z);

        // Проверка на падение
        if (transform.position.y < -7)
        {
            die.Die();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Emerald"))
        {
            jump.jumpStrength = 6;
        }

        if (other.gameObject.CompareTag("Lava"))
        {
            die.DieLava();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Emerald"))
        {
            jump.jumpStrength = 2.7f;
        }
    }
}
