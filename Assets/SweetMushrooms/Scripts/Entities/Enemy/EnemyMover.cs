using UnityEngine;


public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemySettings _enemySettings;
    [SerializeField] private Rigidbody2D _rigidbody;

    private Vector2 _desiredDir;


    public void SetDesiredDirection(Vector2 dir) => _desiredDir = dir.normalized;
    

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _desiredDir * _enemySettings.speed * Time.fixedDeltaTime);
    }
}
