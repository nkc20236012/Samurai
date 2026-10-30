using UnityEngine;

public class PlayerGroundUseCase
{
    private Transform _checkTrasform;
    private float _distance;
    private LayerMask _groundMask;

    public PlayerGroundUseCase(PlayerGroundEntity groundEntity)
    {
        _checkTrasform = groundEntity.CheckTrasform;
        _distance = groundEntity.Distance;
        _groundMask = groundEntity.GroundMask;
    }

    public bool GroundCheck()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(_checkTrasform.position, Vector3.down);
        bool ground = Physics.Raycast(ray, out hit, _distance, _groundMask);
        Debug.Log(ground);
        return ground;
    }
}
