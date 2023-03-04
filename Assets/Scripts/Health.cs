using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0)]
    private float _health;
    [SerializeField, Min(0)]
    private float _damage;
	[SerializeField, Min(0)]
	private float _medkit;
	[SerializeField]
    private Slider _healthSlider;

	private void Start()
	{
		_healthSlider.maxValue = _health;
		_healthSlider.value = _health;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Asteroid _))
		{
			_health -= _damage;
			_healthSlider.value = _health;

			if (_health <= 0)
				SceneManager.LoadScene(0);
		}
		else if (collision.gameObject.TryGetComponent(out Medkit medkit))
		{
			_health = Mathf.Min(_health + _medkit, _healthSlider.maxValue);
			_healthSlider.value = _health;
			Destroy(medkit.gameObject);
		}
	}
}
