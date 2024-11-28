using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField, Range(1, 5)] private float _speed;
    [SerializeField, Range(1, 5)] private float _jumpForce;

    [Header("Ground Check Settings")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _groundCheckRadius;

    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private PlayerInputActions _playerInputActions;

    private bool _isGrounded;
    private bool _isFacingRight = true;

    private PlayerView _playerView;
    private Weapon _weapon;

    public float Speed { get => _speed; set => _speed = value; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerView = GetComponent<PlayerView>();
        _playerInputActions = new PlayerInputActions();
        _weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        CheckGroundStatus();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        Move();
        FlipCharacter();
    }

    private void CheckGroundStatus()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _groundLayer);
    }

    private void UpdateAnimator()
    {
        _playerView.UpdateMovementAnimation(_moveInput.x);
        _playerView.UpdateJumpingAnimation(_isGrounded);
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Move.performed += OnMovePerforned;
        _playerInputActions.Player.Move.canceled += OnMoveCanceled;
        _playerInputActions.Player.Jump.performed += OnJumpPerformed;
        _playerInputActions.Player.Fire.performed += OnShootPerformed;

        _playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Move.performed -= OnMovePerforned;
        _playerInputActions.Player.Move.canceled -= OnMoveCanceled;
        _playerInputActions.Player.Jump.performed -= OnJumpPerformed;
        _playerInputActions.Player.Fire.performed -= OnShootPerformed;

        _playerInputActions.Player.Disable();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_moveInput.x * _speed, _rb.velocity.y);
    }

    private void FlipCharacter()
    {
        if (_moveInput.x > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (_moveInput.x < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void OnMovePerforned(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        Vector2 direction = _isFacingRight ? Vector2.right : Vector2.left;
        _weapon.Shoot(direction);
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheckPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_groundCheckPoint.position, _groundCheckRadius);
        }
    }
}
