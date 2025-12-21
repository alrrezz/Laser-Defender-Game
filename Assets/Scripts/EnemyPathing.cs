using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

//--------------------------------------------- Variables ---------------------------------------------------
    WaveConfig waveConig;
    List<Transform> wayPoints;
    int wayPointsIndex;






//------------------------------------------ Start & Update -------------------------------------------------
    private void Start()
    {
        wayPoints = waveConig.GetWayPoints();

        transform.position = 
            wayPoints[wayPointsIndex].transform.position;
    }
    private void Update()
    {
        Move();
    }






//---------------------------------------------- Methods ----------------------------------------------------
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConig = waveConfig;
    }
    private void Move()
    {
        if(wayPointsIndex < wayPoints.Count)
        {
            var nextWaypoint = 
                wayPoints[wayPointsIndex].transform.position;

            var movementThisFrame =
                Time.deltaTime * 
                waveConig.GetMoveSpeed();

            transform.position = Vector2.MoveTowards
                (transform.position, 
                nextWaypoint,
                movementThisFrame);

            if (transform.position == nextWaypoint)
            {
                wayPointsIndex++;
            }
        }
        else
        { 
            Destroy(gameObject);
        }
        
    }
}
