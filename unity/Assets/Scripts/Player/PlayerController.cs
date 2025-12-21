/**
 * PlayerController.cs - ONE World Metaverse
 * 
 * Main player controller for character movement and input handling.
 * Supports keyboard/mouse and gamepad input via Unity Input System.
 * 
 * @author EXPL / ONE Ecosystem
 * @version 0.1.0
 */

using UnityEngine;
using UnityEngine.InputSystem;

namespace ONEWorld.Player
{
    /// <summary>
    /// Player controller for ONE World metaverse lobby.
    /// Handles movement, rotation, and input processing.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Components
        
        private CharacterController characterController;
        private PlayerInput playerInput;
        
        #endregion
        
        #region Settings
        
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotateSpeed = 180f;
        [SerializeField] private float gravity = -9.81f;
        
        [Header("Camera")]
        [SerializeField] private Transform cameraTarget;
        [SerializeField] private float lookSensitivity = 1f;
        
        [Header("Ground Check")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;
        
        #endregion
        
        #region State
        
        private Vector2 moveInput;
        private Vector2 lookInput;
        private Vector3 velocity;
        private bool isGrounded;
        
        public bool IsMoving => moveInput.sqrMagnitude > 0.01f;
        public Vector3 Velocity => velocity;
        
        #endregion
        
        #region Unity Lifecycle
        
        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            playerInput = GetComponent<PlayerInput>();
        }
        
        private void Start()
        {
            // Lock cursor for first-person control
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        private void Update()
        {
            CheckGrounded();
            HandleMovement();
            HandleRotation();
            ApplyGravity();
        }
        
        #endregion
        
        #region Input Handlers
        
        /// <summary>
        /// Called by Unity Input System for movement input.
        /// </summary>
        public void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }
        
        /// <summary>
        /// Called by Unity Input System for look input.
        /// </summary>
        public void OnLook(InputValue value)
        {
            lookInput = value.Get<Vector2>();
        }
        
        /// <summary>
        /// Called by Unity Input System for interact action.
        /// </summary>
        public void OnInteract(InputValue value)
        {
            if (value.isPressed)
            {
                TryInteract();
            }
        }
        
        /// <summary>
        /// Called by Unity Input System for menu/pause action.
        /// </summary>
        public void OnMenu(InputValue value)
        {
            if (value.isPressed)
            {
                ToggleMenu();
            }
        }
        
        #endregion
        
        #region Movement
        
        private void CheckGrounded()
        {
            if (groundCheck != null)
            {
                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            }
            else
            {
                isGrounded = characterController.isGrounded;
            }
            
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }
        
        private void HandleMovement()
        {
            Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
            characterController.Move(move * moveSpeed * Time.deltaTime);
        }
        
        private void HandleRotation()
        {
            float rotationX = lookInput.x * lookSensitivity * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * rotationX);
            
            // Vertical look is handled by camera
            if (cameraTarget != null)
            {
                float rotationY = lookInput.y * lookSensitivity * rotateSpeed * Time.deltaTime;
                cameraTarget.Rotate(Vector3.left * rotationY);
            }
        }
        
        private void ApplyGravity()
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
        
        #endregion
        
        #region Interactions
        
        private void TryInteract()
        {
            Debug.Log("[ONE World Player] Interact pressed");
            // TODO: Implement interaction raycast
        }
        
        private void ToggleMenu()
        {
            Debug.Log("[ONE World Player] Menu toggled");
            
            bool isLocked = Cursor.lockState == CursorLockMode.Locked;
            Cursor.lockState = isLocked ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isLocked;
        }
        
        #endregion
        
        #region Public API
        
        /// <summary>
        /// Teleport player to position.
        /// </summary>
        public void TeleportTo(Vector3 position)
        {
            characterController.enabled = false;
            transform.position = position;
            characterController.enabled = true;
        }
        
        /// <summary>
        /// Enable or disable player controls.
        /// </summary>
        public void SetControlsEnabled(bool enabled)
        {
            this.enabled = enabled;
        }
        
        #endregion
    }
}
