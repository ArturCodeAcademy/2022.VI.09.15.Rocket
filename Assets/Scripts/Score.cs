using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField, Range(0.1f, 10)]
    private float _scorePerSecond;

    private float _score;
    private int _best;

    private const string HIGH_SCORE_KEY = "HSK";

	private void Start()
	{
		_best = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
	}

	private void Update()
	{
		_score += _scorePerSecond * Time.deltaTime;
		_scoreText.text = $"Score: {(int)_score}\nBest: {_best}";
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt(HIGH_SCORE_KEY, (int)Mathf.Max(_score, _best));
	}
}
