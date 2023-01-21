using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(0.1f)]
    private float _spawnPause;
    [SerializeField]
    private GameObject[] _asteroidPrefabs;

    private const float OFFSET = 3;

    private IEnumerator Start()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnPause);

        while (true)
        {
            Vector3 pos = new Vector3
            (
                Random.Range(Borders.Instance.LeftBorder, Borders.Instance.RightBorder),
                Borders.Instance.UpBorder + OFFSET
            );
            GameObject asteroid = _asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Length)];
            Instantiate(asteroid, pos, Quaternion.identity);

            yield return wait;
        }
    }
}
