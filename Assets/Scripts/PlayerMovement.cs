using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private Vector3 move;
	private Vector3 mouse;

	public float maxSpeed;
	
	public Camera _camera;

	private void Start() {
		this._transform = transform;
		this._rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		move.x = Input.GetAxis("Horizontal");
		move.y = Input.GetAxis("Vertical");

		Vector3 m2w = _camera.ScreenToWorldPoint(Input.mousePosition);
		mouse.x = m2w.x;
		mouse.y = m2w.y;
	}

	private void FixedUpdate() {
		Move();
		Flip();
	}

	private void Move() {
		this._rigidbody.velocity = move * maxSpeed;
	}

	private void Flip() {
		if (this._transform.localScale.x < 0 && mouse.x > this._transform.position.x || 
		    this._transform.localScale.x > 0 && mouse.x < this._transform.position.x) {
			FlipX();
		}
	}

	private void FlipX() {
		Vector3 scale = this._transform.localScale;
		scale.x *= -1;
		this._transform.localScale = scale;
	}
}