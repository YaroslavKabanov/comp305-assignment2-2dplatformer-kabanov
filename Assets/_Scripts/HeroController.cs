using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	// private variables 
	private Animator _animator;
	private float _move;
	private float _jump;
	private bool _facialRight;
	private Transform _transform;


	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._move = 0f;
		this._jump = 0f;
		this._animator.SetInteger ("AnimState", 0);
		this._facialRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		this._move = Input.GetAxis ("Horizontal");
		this._jump = Input.GetAxis ("Vertical");
		if (this._move != 0) {
			if (this._move > 0) {
				this._facialRight = true;
			}
			if (this._move < 0) {
				this._facialRight = false;
			}

			this._animator.SetInteger ("AnimState", 1);
		} else {
			this._animator.SetInteger ("AnimState", 0);
		}


		if (this._jump > 0) {
			this._animator.SetInteger ("AnimState", 2);
		}

		this._flip ();
	}

	private void _flip() {
		if(this._facialRight) {
			this._transform.localScale = new Vector2 (1, 1);
		} else {
			this._transform.localScale = new Vector2 (-1, 1);
		}
	}
}