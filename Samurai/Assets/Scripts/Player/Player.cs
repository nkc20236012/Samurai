using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInputAction { get; set; }
    public PlayerCameraEntity CameraEntity { get; set; }

    [SerializeField]
    private PlayerStatus _statusData;
    [SerializeField]
    private PlayerStateData _stateData;

    private PlayerStateMachine _stateMachine;
    private PlayerInput _input => PlayerInputAction;
    private PlayerCameraEntity _cameraEntity => CameraEntity;
    public void Start()
    {
        Rigidbody rigidbody = GetComponentInChildren<Rigidbody>();

        //Entity
        PlayerStatusEntity statusEntity = new PlayerStatusEntity(_statusData);
        PlayerInputEntity inputEntity = new PlayerInputEntity(_input);
        PlayerColliderEntity colliderEntity = new PlayerColliderEntity();

        //UseCase
        PlayerMoveUseCase moveUseCase = new PlayerMoveUseCase(inputEntity, statusEntity,_cameraEntity,
            rigidbody,this.transform);
        PlayerCameraUseCase cameraUseCase = new PlayerCameraUseCase(CameraEntity);
        PlayerColliderUseCase colliderUseCase = new PlayerColliderUseCase(colliderEntity);

        //Context
        PlayerBaseContext baseContext =
            new PlayerBaseContext(statusEntity, inputEntity,_cameraEntity,moveUseCase,
            cameraUseCase,colliderUseCase);

        _stateMachine = new PlayerStateMachine(baseContext,_stateData);
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
