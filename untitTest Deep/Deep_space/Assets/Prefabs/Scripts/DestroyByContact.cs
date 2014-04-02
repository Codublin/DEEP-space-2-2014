using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explositionPrefab;
	public GameObject playerExplosition;
	private GameManager _gameManager;
	private int scoreValue = 10;

	void Start()
	{
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Boundary")
		{
			return;
		}
		Instantiate(explositionPrefab, transform.position, Quaternion.identity);

		if (col.tag == "Player")
		{
			Instantiate(playerExplosition, col.transform.position, Quaternion.identity);
			_gameManager.GameOver();
		}
		_gameManager.AddScore(scoreValue);
		Destroy(col.gameObject);
		Destroy(this.gameObject);
	}	
}
