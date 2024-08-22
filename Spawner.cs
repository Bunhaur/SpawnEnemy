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
        _createEnemyWork = StartCoroutine(CreateEnemies());
    }

    private IEnumerator CreateEnemies()
    {
        var timer = new WaitForSeconds(_spawnTime);
        Enemy enemy;

        while (true)
        {
            enemy = Instantiate(_enemy, GetRandomSpawnPoint(), Quaternion.identity);
            enemy.SetBaseRotation(GetRandomRotation());
            yield return timer;
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return _points[UnityEngine.Random.Range(0, _points.Length)];
    }

    private Quaternion GetRandomRotation()
    {
        float maxRotationY = 359;
        Vector3 rotation = new Vector3(0, UnityEngine.Random.Range(0, maxRotationY));

        return Quaternion.Euler(rotation);
    }
}