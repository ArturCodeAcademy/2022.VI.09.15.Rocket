using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffectPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Asteroid _))
        {
            Instantiate(_destroyEffectPrefab, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
