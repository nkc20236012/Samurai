using UnityEngine;

public class PlayerMoveUseCase
{
    private PlayerInputEntity _inputEntity;
    private PlayerStatusEntity _statusEntity;
    private PlayerCameraEntity _cameraEntity;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;
    public PlayerMoveUseCase(PlayerInputEntity inputEntity,PlayerStatusEntity statusEntity,
        PlayerCameraEntity cameraEntity,Rigidbody rigidbody,Transform transform)
    {
        _inputEntity = inputEntity;
        _statusEntity = statusEntity;
        _cameraEntity = cameraEntity;
        _rigidbody = rigidbody;
        _playerTransform = transform;
    }

    //引数の方向に移動、回転
    public void Move(Quaternion cameraAngle, Vector3 moveVelocity)
    {
        if (_inputEntity.MoveInput.magnitude != 0.0f)
        {
            _playerTransform.rotation =
                Quaternion.Slerp(_playerTransform.rotation, cameraAngle, 0.2f
                 );
        }
        _rigidbody.linearVelocity =
            new Vector3(moveVelocity.x, _rigidbody.linearVelocity.y, moveVelocity.z);
    }

    //入力方向に移動指示
    public void Walk()
    {
        Quaternion cameraAngle =
            Quaternion.AngleAxis(_cameraEntity.CameraTrancform.eulerAngles.y, Vector3.up);
        Vector3 moveVelocity = cameraAngle * (_inputEntity.MoveInput * _statusEntity.Speed);
        Move(cameraAngle, moveVelocity);
    }

    //カメラ方向に移動指示
    public void Boost()
    {
        Quaternion cameraAngle =
            Quaternion.AngleAxis(_cameraEntity.CameraTrancform.eulerAngles.y, Vector3.up);
        Vector3 moveVelocity = cameraAngle * (_playerTransform.forward * _statusEntity.Speed);
        Move(cameraAngle, moveVelocity);
    }

    public void QuickRotate()
    {
        Quaternion cameraAngle =
            Quaternion.AngleAxis(_cameraEntity.CameraTrancform.eulerAngles.y, Vector3.up);
        _playerTransform.rotation = cameraAngle;
        Debug.Log("A");
    }
}
