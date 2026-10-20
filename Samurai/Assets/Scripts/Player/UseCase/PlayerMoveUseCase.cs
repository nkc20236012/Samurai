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

    public void Move()
    {
        Quaternion cameraAngle =
            Quaternion.AngleAxis(_cameraEntity.CameraTrancform.eulerAngles.y, Vector3.up);
        Vector3 moveVelocity = cameraAngle*(_inputEntity.MoveInput * _statusEntity.Speed);
        if (_inputEntity.MoveInput.magnitude != 0.0f)
        {
            _playerTransform.rotation =
                Quaternion.Slerp(_playerTransform.rotation, Quaternion.LookRotation(
                _inputEntity.MoveInput) * cameraAngle, 0.2f
                 );
        }
        _rigidbody.linearVelocity =
            new Vector3(moveVelocity.x, _rigidbody.linearVelocity.y, moveVelocity.z);
    }
}
