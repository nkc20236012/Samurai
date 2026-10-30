using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundEntity
{
    public Transform CheckTrasform { get; private set; }
    public float Distance {  get; private set; }
    public LayerMask GroundMask {  get; private set; }

    public PlayerGroundEntity(Transform transform,float distance,LayerMask mask)
    {
        CheckTrasform = transform;
        Distance = distance;
        GroundMask = mask;
    }
}
