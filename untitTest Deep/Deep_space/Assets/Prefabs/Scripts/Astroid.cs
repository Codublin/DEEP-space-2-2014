using UnityEngine;
using System.Collections;

public class Astroid : MonoBehaviour
{

	[SerializeField]
	private float _speed;
	private PlayerController _player;
	
	void Start()
	{
		rigidbody.velocity = transform.forward * _speed;
		_player = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	void Update()
	{
		var distance = Vector3.Distance(_player.transform.position, transform.position);
		Debug.Log(distance);
	}
}
