using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerSettings _playerSettings;
    [SerializeField] private Rigidbody2D _rb;

    private Vector2 _moveInput;
    private InputSystem_Actions _inputSystem;


    private void Awake() => _inputSystem = new InputSystem_Actions();

    private void OnEnable()
    {
        _inputSystem.Player.Enable();
        _inputSystem.Player.Move.performed += OnMovePerformed;
        _inputSystem.Player.Move.canceled += OnMoveCanceled;
    }

    private void FixedUpdate() => _rb.linearVelocity = _moveInput * _playerSettings.speed;

    private void OnDisable()
    {
        _inputSystem.Player.Move.canceled -= OnMoveCanceled;
        _inputSystem.Player.Move.performed -= OnMovePerformed;
        _inputSystem.Player.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context) => _moveInput = context.ReadValue<Vector2>();
    private void OnMoveCanceled(InputAction.CallbackContext context) => _moveInput = Vector2.zero;
}
