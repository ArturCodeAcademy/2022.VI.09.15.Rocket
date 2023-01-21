using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0.5f, 20)] private float _speed;
    [SerializeField, Range(0, 90)] private float _rotation;
    [SerializeField, Range(0.01f, 1)] private float _rotationTime;

    private float _timer = 0;

    private void Update()
    {
#if UNITY_ANDROID
        float x = acceleration.x;
#else
        float x = Input.GetAxis("Horizontal");
#endif

        Vector3 translation = x * Time.deltaTime * Vector3.right * _speed;
        Vector3 newPos = transform.position + translation;
        newPos.x = Mathf.Clamp(newPos.x, Borders.Instance.LeftBorder, Borders.Instance.RightBorder);
        transform.position = newPos;

        if (x != 0)
            _timer = Mathf.Clamp(_timer + x * Time.deltaTime, -_rotationTime, _rotationTime);
        else
        {
            float time = Mathf.Clamp(Time.deltaTime, 0, Mathf.Abs(_timer));
            _timer += _timer > 0? -time : time;
        }

        transform.rotation = Quaternion.Lerp
        (
            Quaternion.identity,
            Quaternion.Euler(0, 0, _timer > 0? -_rotation : _rotation),
            Mathf.Abs(_timer / _rotationTime)
        );
    }
}
