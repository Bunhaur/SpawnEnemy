using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}