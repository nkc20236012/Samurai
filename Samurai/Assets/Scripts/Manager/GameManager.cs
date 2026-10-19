using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    void Awake()
    {
        InputController inputController = new InputController();
        GameObject playerObject = Instantiate(_playerPrefab);
        playerObject.GetComponent<Player>().PlayerInputAction 
            = inputController.PlayerInputAction;

    }

    void Update()
    {
        
    }
}
