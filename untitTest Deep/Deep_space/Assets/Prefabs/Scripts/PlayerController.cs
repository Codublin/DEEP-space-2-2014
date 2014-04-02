using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public Boundary boundary;
	public GameObject boltPrefab;
	public Transform shotSpawn;


	[SerializeField]
	private float _speed = 5.0f;
	private float _tilt = 4.0f;
	private float _fireRate = 0.25f;
	private float _nextFire = -1.0f;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
		{
			_nextFire = Time.time + _fireRate;
			Instantiate(boltPrefab, shotSpawn.position, Quaternion.identity);
			audio.Play();
		}
	}

	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(h, 0, v);
		rigidbody.velocity = direction * _speed;

		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
				0,
				Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
			);

		rigidbody.rotation = Quaternion.Euler(0f, 0f, rigidbody.velocity.x * -_tilt);
	}
}
