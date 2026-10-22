using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInputAction { get; set; }
    public PlayerCameraEntity CameraEntity { get; set; }

    [SerializeField]
    private PlayerStatus _statusData;

    private PlayerStateMachine _stateMachine;
    private PlayerInput _input => PlayerInputAction;
    private PlayerCameraEntity _cameraEntity => CameraEntity;
    private PlayerStatusEntity _statusEntity;
    private PlayerInputEntity _inputEntity;
    private PlayerMoveUseCase _moveUseCase;
    public void Start()
    {
        Rigidbody rigidbody = GetComponentInChildren<Rigidbody>();
        _statusEntity = new PlayerStatusEntity(_statusData);
        _inputEntity = new PlayerInputEntity(_input);
        _moveUseCase = new PlayerMoveUseCase(_inputEntity, _statusEntity,_cameraEntity,
            rigidbody,this.transform);
        PlayerBaseContext baseContext =
            new PlayerBaseContext(_statusEntity, _inputEntity,_cameraEntity,_moveUseCase);
        _stateMachine = new PlayerStateMachine(baseContext);
        _stateMachine.Initialize(StateType.Idle);
    }

    public void Update()
    {
        _stateMachine.OnUpdate();
    }

    public void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
    }
}
