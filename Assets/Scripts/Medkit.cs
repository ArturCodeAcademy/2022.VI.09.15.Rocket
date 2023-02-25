using UnityEngine;

public class Medkit : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private const float OFFSET = 3;
    private const float VELOCITY = 2;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.AddForce
		(
			new Vector2(Random.Range(-1, 1), -1).normalized * VELOCITY,
			ForceMode2D.Impulse
		);
		_rigidbody.AddTorque(Random.Range(-100, 100));
	}

	private void Update()
	{
		if (transform.position.y < Borders.Instance.DownBorder - OFFSET)
			Destroy(gameObject);

		if (transform.position.x > Borders.Instance.RightBorder
			|| transform.position.x < Borders.Instance.LeftBorder)
		{
			Vector2 velocity = _rigidbody.velocity;
			velocity.x *= -1;
			_rigidbody.velocity = velocity;
		}
	}
}
