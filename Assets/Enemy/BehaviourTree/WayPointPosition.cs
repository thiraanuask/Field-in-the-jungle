using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.InputSystem.XR.Haptics;

public class WayPointPosition : ActionNode
{
    public int currentWaypointIdx = -1;
    public SetWaypoint waypoint;
    public HitEnemy hitEnemy;
    
    protected override void OnStart() 
    {
        hitEnemy = context.gameObject.GetComponentInChildren<HitEnemy>();
        waypoint = context.gameObject.GetComponent<SetWaypoint>();
        float lastDist = Mathf.Infinity;
        
        for (int i = 0; i < waypoint.wayPoints.Count; i++)
        {
            GameObject thisWP = waypoint.wayPoints[i].gameObject;
            float distance = Vector3.Distance(context.gameObject.transform.position, thisWP.transform.position);
            if(distance < lastDist)
            {
                currentWaypointIdx = i;
                lastDist = distance;

                blackboard.moveToPosition = thisWP.transform.position;
            }            
        }
    }

    protected override void OnStop() 
    {
    }

    protected override State OnUpdate()
    {
        if (hitEnemy.isDead)
        {
            return State.Success;
        }
        
        if (currentWaypointIdx >= waypoint.wayPoints.Count-1)
            currentWaypointIdx = 0;
        else
            currentWaypointIdx++;
        
        blackboard.moveToPosition = waypoint.wayPoints[currentWaypointIdx].transform.position;
        
        return State.Failure;
    }
}
