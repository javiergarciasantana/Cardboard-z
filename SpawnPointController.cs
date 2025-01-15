using UnityEngine;
using System.Collections;

public class SpawnPointController : MonoBehaviour
{
  public GameObject spawnPointPrefab;
  public int numberOfSpawnPoints = 10;
  public float distanceBetweenPoints = 20.0f;
  public float waitingTime = 8.0f;

  void Start()
  {
    StartCoroutine(GenerateSpawnPoints());
  }

  IEnumerator GenerateSpawnPoints()
  {
    for (int i = 0; i < numberOfSpawnPoints; i++)
    {
      Vector3 spawnPosition = transform.position + new Vector3(i * distanceBetweenPoints, 0, 0);
      Instantiate(spawnPointPrefab, spawnPosition, Quaternion.identity);
      yield return new WaitForSeconds(waitingTime);
    }
  }
}