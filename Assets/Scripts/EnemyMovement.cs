using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private Vector3 move;

	public float speed = 1f;
	public Vector3 target;

	void Awake() {
		this._transform = transform;
		this._rigidbody = GetComponent<Rigidbody2D>();
		this.target = this._transform.position;
	}

	void Update() {
		if (target != _transform.position) {
			move = (target - _transform.position);
			move.Normalize();
			move *= speed;
		}
	}

	private void FixedUpdate() {
		Move();
	}

	private void Move() {
		this._rigidbody.velocity = move * speed;
	}

	public void Stop() {
		this.target = this._transform.position;
		this.move = Vector3.zero;
	}
}