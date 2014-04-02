using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject hazardPrefab;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool _gameOver;
	private bool _restart;

	private int score;

	void Start()
	{
		_gameOver = false;
		_restart = false;

		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	void Update()
	{
		if (_restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-6f, 7f), 0f, 16f);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazardPrefab, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (_gameOver)
			{
				restartText.text = "Press 'R' to Restart";
				_restart = true;
				break;
			}
		}

	}

	public void AddScore(int value)
	{
		score += value;
		UpdateScore();
	}


	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "GameOver";
		_gameOver = true;
	}
}
