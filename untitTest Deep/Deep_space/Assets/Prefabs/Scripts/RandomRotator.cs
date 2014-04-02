using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
	[SerializeField]
	private float _tumble;

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * _tumble;
	}
}
