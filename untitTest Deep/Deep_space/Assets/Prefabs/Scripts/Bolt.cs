using UnityEngine;
using System.Collections;

public class Bolt : MonoBehaviour
{
	[SerializeField]
	private float _speed;

	void Start()
	{
		rigidbody.velocity = transform.forward * _speed;

	}
}
