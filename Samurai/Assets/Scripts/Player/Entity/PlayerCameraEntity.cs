using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraEntity
{
    public Transform CameraTrancform;
    public CinemachineCamera PlayerCamera;
    private CinemachineInputAxisController _inputAxisController;
    private float _cameraSpeed;
    private float _defultSpeed;
    private float _boostSpeed;
    public PlayerCameraEntity(Transform transform,CinemachineCamera cinemachineCamera,
        CinemachineInputAxisController inputAxisController,float defultSpeed,float boostmodeSpeed)
    {
        CameraTrancform = transform;
        PlayerCamera = cinemachineCamera;
        _inputAxisController = inputAxisController;
        _cameraSpeed = defultSpeed;
        _defultSpeed = defultSpeed;
        _boostSpeed = boostmodeSpeed;
    }

    public void WalkMode()
    {
        _cameraSpeed = _defultSpeed;
        CameraSpeedChange();
    }
    public void BoostMode()
    {
        _cameraSpeed = _boostSpeed;
        Debug.Log("A"+  _cameraSpeed);
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
