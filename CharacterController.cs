using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
  // Speed settings for movement and sprint
  public float moveSpeed = 5f;
  public float sprintSpeed = 10f; // Speed when sprinting

  private Vector2 moveInput;
  private bool isSprinting = false; // To track sprint status

  // Reference to the camera
  public Transform cameraTransform;

  [Header("Shooting Settings")]
  public float shootRange = 15f; // Maximum distance for shooting
  public LayerMask zombieLayer; // Layer for zombies
  public GameObject shootEffectPrefab; // Optional: effect when shooting
  public Transform gunTip; // Position from where bullets are shot

  void FixedUpdate()
  {
    // Get keyboard and gamepad inputs from the new Input System
    Keyboard keyboard = Keyboard.current;
    Gamepad gamepad = Gamepad.current;

    // Reset movement input
    moveInput = Vector2.zero;

    // Handle keyboard inputs
    if (keyboard != null)
    {
      // Set movement input based on keyboard
      if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) moveInput.y += 1;
      if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) moveInput.y -= 1;
      if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) moveInput.x -= 1;
      if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) moveInput.x += 1;

      if (keyboard.leftShiftKey.isPressed) isSprinting = true;

      if (keyboard.spaceKey.wasPressedThisFrame) Shoot();
    }

    // Handle gamepad inputs (only if gamepad is connected)
    if (gamepad != null)
    {
      // Set movement input based on gamepad left stick
      moveInput = gamepad.leftStick.ReadValue(); 

      if (gamepad.leftStickButton.isPressed && moveInput.y > 0) isSprinting = true;
    }

    // Normalize movement input to ensure smooth diagonal movement
    moveInput = moveInput.normalized;

    // Check if the player is moving forward or backward (stop sprinting when not moving)
    if (moveInput == Vector2.zero || moveInput.y <= 0)
    {
      isSprinting = false; // Stop sprinting if player is not moving or moving backward
    }
  }

  void FixedUpdate()
  {
    // Apply movement in FixedUpdate
    ApplyMovement();
  }

  /// <summary>
  /// Handles player movement relative to the camera.
  /// </summary>
  private void ApplyMovement()
  {
    if (cameraTransform != null)
    {
      // Calculate movement direction relative to the camera
      Vector3 forward = cameraTransform.forward;
      Vector3 right = cameraTransform.right;

      forward.y = 0; // Prevent the movement from going up/down with the camera's tilt
      right.y = 0; // Prevent the movement from going up/down with the camera's tilt

      Vector3 moveDirection = (forward * moveInput.y + right * moveInput.x).normalized;

      // Scale movement by speed
      float speed = isSprinting ? sprintSpeed : moveSpeed;
      moveDirection *= speed * Time.deltaTime;

      // Apply movement in world space
      transform.Translate(moveDirection, Space.World);
    }
  }

  /// <summary>
  /// Handles shooting logic.
  /// </summary>
  private void Shoot()
  {
    if (cameraTransform == null) return;

    Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
    if (Physics.Raycast(ray, out RaycastHit hit, shootRange, zombieLayer))
    {
      if (hit.collider.CompareTag("Zombie"))
      {
        Debug.Log("Zombie hit!");

        // Destroy the zombie
        Destroy(hit.collider.gameObject);

        // Instantiate shooting effect
        if (shootEffectPrefab != null && gunTip != null)
        {
          Instantiate(shootEffectPrefab, gunTip.position, Quaternion.identity);
        }
      }
    }
    else
    {
      Debug.Log("Missed!");
    }
  }
}
