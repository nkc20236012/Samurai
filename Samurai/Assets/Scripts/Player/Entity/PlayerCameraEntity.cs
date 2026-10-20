using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraEntity
{
    public Transform CameraTrancform;
    public CinemachineCamera PlayerCamera;
    public PlayerCameraEntity(Transform transform,CinemachineCamera cinemachineCamera)
    {
        CameraTrancform = transform;
        PlayerCamera = cinemachineCamera;
    }
}
