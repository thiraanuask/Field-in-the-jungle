using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MouseLook : CinemachineExtension
{
    [SerializeField] 
    private float horizontalSpeed = 10f;

    [SerializeField]
    private float verticalSpeed = 10f;
    
    private float clampAngle = 80;
    
    private Vector3 rotationStart;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                rotationStart.x += Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
                rotationStart.y += Input.GetAxis("Mouse Y") * verticalSpeed * Time.deltaTime;
                rotationStart.y = Mathf.Clamp(rotationStart.y, -clampAngle, clampAngle);
                state.RawOrientation = Quaternion.Euler(-rotationStart.y,rotationStart.x,0f);
            }
        }
    }
}
