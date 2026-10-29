using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraEntity
{
    public Transform CameraTrancform { get; private set; }
    public CinemachineCamera PlayerCamera { get; private set; }
    public CinemachineInputAxisController InputAxisController { get; private set; }
    public CinemachineOrbitalFollow OrbitalFollow { get; private set; }
    public CameraData CameraStatusData { get; private set; }
    public float CameraSpeed { get; private set; }

    public PlayerCameraEntity(Transform transform,CinemachineCamera cinemachineCamera,
        CinemachineInputAxisController inputAxisController,CinemachineOrbitalFollow orbitalFollow,
        CameraData cameraData)
    {
        CameraTrancform = transform;
        PlayerCamera = cinemachineCamera;
        InputAxisController = inputAxisController;
        OrbitalFollow = orbitalFollow;
        CameraStatusData = cameraData;
        CameraSpeed = CameraStatusData.CameraDefaultSpeed;
    }

}
