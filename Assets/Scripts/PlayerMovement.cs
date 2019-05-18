using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private Vector3 move;

	public float maxSpeed;

	void Start() {
		this._transform = GetComponent<Transform>();
		this._rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		move.x = Input.GetAxis("Horizontal");
		move.y = Input.GetAxis("Vertical");
	}

	private void FixedUpdate() {
		this._rigidbody.velocity = move * maxSpeed;
	}
}