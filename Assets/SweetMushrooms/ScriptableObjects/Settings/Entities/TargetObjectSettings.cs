using UnityEngine;


[CreateAssetMenu(fileName = "NewTargetObjectSettings", menuName = "Settings/TargetObjectSettings")]
public class TargetObjectSettings : ScriptableObject
{
    public float captureCooldown = 0.25f;
}
