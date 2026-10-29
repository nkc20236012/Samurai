using UnityEngine;

[CreateAssetMenu(menuName = "CameraData")]
public class CameraData : ScriptableObject
{
    public GameObject CameraPrefab;
    public float CameraDefaultSpeed;
    public float CameraBoostmodeSpeed;
    public float MaxVerticalRange;
    public float MinVerticalRange;
    public float BoostMaxVerticalRange;
    public float BoostMinVerticalRange;
}
