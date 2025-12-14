using UnityEngine;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class CameraBehaviour : MonoBehaviour, ICameraActions
{
    private InputSystem_Actions inputActions;

    [Header("Target Settings")]
    public Transform target;
    public float distance = 10.0f;

    [Header("Rotation Settings")]
    public float xSensitivity = 2.0f;
    public float ySensitivity = 2.0f;
    public float yMinLimit = -80f;
    public float yMaxLimit = 80f;
    private bool isOrbiting = false;

    [Header("Movement Settings")]
    public float smoothTime = 0.2f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Camera.SetCallbacks(this);
        inputActions.Camera.Enable();
    }
    void OnEnable()
    {
        inputActions.Enable();
    }
    void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        if (target == null)
        {
            enabled = false;
            return;
        }
        Vector3 angles = transform.eulerAngles;
        currentX = -angles.y;
        currentY = -angles.x;
    }
    private void LateUpdate()
    {
        if (target == null) return;

        if (isOrbiting)
        {
            GetScrollValue();
        }
        UpdateCameraPosition();
    }
    public void OnOrbit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isOrbiting = true;
        }
        else if (context.canceled)
        {
            isOrbiting = false;
        }
    }
    public void GetScrollValue()
    {
        Vector2 mouse = Mouse.current.delta.ReadValue();
        currentX += mouse.x * xSensitivity;
        currentY += mouse.y * ySensitivity;
        currentY = Mathf.Clamp(currentY, yMinLimit, yMaxLimit);
    }
    public void OnZoom(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 zoom = context.ReadValue<Vector2>();
            distance -= zoom.y;
        }
    }

    private void UpdateCameraPosition()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position - rotation * Vector3.back * distance;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.LookAt(target);
    }
}
