using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraUseCase:MonoBehaviour
{
    private CinemachineInputAxisController _inputAxisController;
    private CinemachineOrbitalFollow _orbitalFollow;
    private CameraData _cameraStatusData;
    private float _cameraSpeed;

    public PlayerCameraUseCase(PlayerCameraEntity cameraEntity)
    {
        _inputAxisController = cameraEntity.InputAxisController;
        _orbitalFollow = cameraEntity.OrbitalFollow;
        _cameraStatusData = cameraEntity.CameraStatusData;
        _cameraSpeed = cameraEntity.CameraSpeed;
    }
    public void WalkMode()
    {
        _cameraSpeed = _cameraStatusData.CameraDefaultSpeed;
        _orbitalFollow.VerticalAxis.Range =
            new Vector2(_cameraStatusData.MinVerticalRange, _cameraStatusData.MaxVerticalRange);
        CameraSpeedChange();
    }
    public void BoostMode()
    {
        _cameraSpeed = _cameraStatusData.CameraBoostmodeSpeed;
        _orbitalFollow.VerticalAxis.Range =
            new Vector2(_cameraStatusData.BoostMinVerticalRange, _cameraStatusData.BoostMaxVerticalRange);

        CameraSpeedChange();
    }
    private void CameraSpeedChange()
    {
        foreach (var c in _inputAxisController.Controllers)
        {
            if (c.Name == "Look Orbit X")
            {
                c.Input.Gain = _cameraSpeed;
            }
            else if (c.Name == "Look Orbit Y")
            {
                c.Input.Gain = -_cameraSpeed;
            }
        }
    }
}
