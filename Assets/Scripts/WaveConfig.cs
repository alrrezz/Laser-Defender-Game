using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject
{

//--------------------------------------------- Variables ---------------------------------------------------
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 10;
    [SerializeField] float moveSpeed = 2f;



//---------------------------------------------- Methods ----------------------------------------------------
    public List<Transform> GetWayPoints() 
    {
        List<Transform> wayPointsList = new List<Transform>();

        foreach (Transform child  in pathPrefab.transform)
        {
            wayPointsList.Add(child);
        }

        return wayPointsList;
    }
    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public float GetTimeBetweenSpawns() {  return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() {  return spawnRandomFactor; }
    public int GetNumberOfEnemies() {  return numberOfEnemies; }
    public float GetMoveSpeed() {  return moveSpeed; }
}
