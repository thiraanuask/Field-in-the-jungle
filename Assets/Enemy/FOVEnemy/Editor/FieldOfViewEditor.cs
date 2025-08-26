using System;
using System.Collections;
using System.Collections.Generic;
using LastHopeStudio.AI;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    public void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView) target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up,Vector3.forward, 360,fov.viewRadius );
        Vector3 viewAngleA = fov.DirectionFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.DirectionFromAngle(fov.viewAngle / 2, false);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

        Handles.color = Color.red;
        if(fov.visibleTarget != null)
            Handles.DrawLine(fov.transform.position, fov.visibleTarget.position);
    }
}
