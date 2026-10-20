using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInputAction { get; set; }
    public PlayerCameraEntity CameraEntity { get; set; }

    [SerializeField]
    private PlayerStatus _statusData;

    private Rigidbody _rigidbody;
    private PlayerInput _input => PlayerInputAction;
    private PlayerCameraEntity _cameraEntity => CameraEntity;
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    public void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _statusEntity = new PlayerStatusEntity(_statusData);
        _inputEntity = new PlayerInputEntity(_input);
        _moveUseCase = new PlayerMoveUseCase(_inputEntity, _statusEntity,_cameraEntity,
            _rigidbody,this.transform);
    }

    public void FixedUpdate()
    {
        if(_inputEntity.IsSprint)
        {
            _statusEntity.SprintMode();
        }
        else
        {
            _statusEntity.MoveMode();
        }
        _moveUseCase.Move();
    }
}
