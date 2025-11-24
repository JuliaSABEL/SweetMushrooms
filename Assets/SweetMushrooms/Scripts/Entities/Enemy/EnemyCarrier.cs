using UnityEngine;


public class EnemyCarrier : MonoBehaviour, ICarrier
{
    [field: SerializeField] public Transform CarryPoint { get; private set; }
}
