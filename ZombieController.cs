using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls target object's behavior.
/// </summary>
public class ZombieController : MonoBehaviour
{
  public Material InactiveMaterial;
  public Material GazedAtMaterial;
  public Animator animator;
  public Transform playerCamera;
  public float speed;
  private const float _minObjectDistance = 2.5f;
  private const float _maxObjectDistance = 7.5f;
  private const float _minObjectHeight = 0.5f;
  private const float _maxObjectHeight = 3.5f;

  public Transform[] spawnPoints;
  private Rigidbody rb;
  private Gamepad gamepad;
  private UnityEngine.AI.NavMeshAgent agent;

  /// <summary>
  /// Start is called before the first frame update.
  /// </summary>
  public void Start()
  {
    // Ensure the camera is assigned
    if (playerCamera == null)
    {
      Debug.LogError("PlayerCamera is not assigned. Please assign the main camera in the inspector.");
      return;
    }

    rb = GetComponent<Rigidbody>();

    if (rb == null)
    {
      Debug.LogError("Rigidbody component is missing from the Zombie object.");
    }

    if (spawnPoints == null || spawnPoints.Length == 0)
    {
      Debug.LogError("SpawnPoints array is empty. Assign spawn points in the Inspector.");
    }

    SetMaterial(false); // Set initial material to inactive
    gamepad = Gamepad.current;
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
  }

  void FixedUpdate()
  {
    if (playerCamera == null || rb == null) return;

    agent.SetDestination(playerCamera.position);

    float distanceToPlayer = Vector3.Distance(playerCamera.position, transform.position);

    // Check if the zombie is within attack range
    if (distanceToPlayer <= 4.0f)
    {
      animator.SetBool("isAttacking", true); // Trigger the attack layer
    }
    else
    {
      animator.SetBool("isAttacking", false); // Return to idle/walk
    }
  }

  /// <summary>
  /// This method is called by the Main Camera when it starts gazing at this GameObject.
  /// </summary>
  public void OnPointerEnter()
  {
    SetMaterial(true);
  }

  /// <summary>
  /// This method is called by the Main Camera when it stops gazing at this GameObject.
  /// </summary>
  public void OnPointerExit()
  {
    SetMaterial(false);
  }

  /// <summary>
  /// Sets this instance's material according to gazedAt status.
  /// </summary>
  /// <param name="gazedAt">True if this object is being gazed at, false otherwise.</param>
  private void SetMaterial(bool gazedAt)
  {
    if (gazedAt)
    {
      if (spawnPoints != null && spawnPoints.Length > 0)
      {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[randomIndex].position;
      }
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      PlayerInterface playerInterface = collision.gameObject.GetComponent<PlayerInterface>();
      if (playerInterface != null)
      {
        playerInterface.TakeDamage();
      }
    }
  }
}