using UnityEngine;


public class PlayerCarrier : MonoBehaviour, ICarrier
{
    [field: SerializeField] public Transform CarryPoint { get; private set; }
}
