using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector3[] _points;
    [SerializeField] private Enemy _enemy;

    private float _spawnTime = 2f;
    private Coroutine _createEnemyWork;

    private void Start()
    {
        _createEnemyWork = StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        while (true)
        {
            Instantiate(_enemy, GetRandomSpawnPoint(), GetRandomRotation());
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Vector3 point = _points[UnityEngine.Random.Range(0, _points.Length)];

        return point;
    }

    private Quaternion GetRandomRotation()
    {
        float maxRotationY = 359;
        Vector3 rotation = new Vector3(0, UnityEngine.Random.Range(0, maxRotationY));

        return Quaternion.Euler(rotation);
    }
}