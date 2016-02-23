﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class VelocityRange {
	// public vars 
	public float min;
	public float max; 

	// constructor
	public VelocityRange (float min, float max) {
		this.min = min;
		this.max = max;
	}
}

public class HeroController : MonoBehaviour {

	// public variables
	public VelocityRange velocityRange;
	public float moveForce;
	public float jumpForce;
	public Transform groundCheck;

	// private variables 
	private Animator _animator;
	private float _move = 0f;
	private float _jump = 0f;
	private bool _facialRight;
	private Transform _transform;
	private Rigidbody2D _rigidBody2D;
	private bool _isGrounded;



	// Use this for initialization
	void Start () {
		// initialize public variables
		this.velocityRange = new VelocityRange (300f,30000f);

		this.moveForce = 1000f;
		this.jumpForce = 35000f;
	
	
		// initialize private variables
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();
		this._rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		this._move = 0f;
		this._jump = 0f;
		this._animator.SetInteger ("Anim_State", 0);
		this._facialRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		this._isGrounded = Physics2D.Linecast (
			this._transform.position,
			this.groundCheck.position,
			1 << LayerMask.NameToLayer ("Ground"));
		

		float forceX = 0f;
		float forceY = 0f;

		// get absolute value of velocity
		float absVelX = Mathf.Abs (this._rigidBody2D.velocity.x);
		float absVelY = Mathf.Abs (this._rigidBody2D.velocity.y);


		// check if player is grounded and then he can move
		if (this._isGrounded) {
			// get a number betwee -1 to 1 for Hor and Vert axes
			this._move = Input.GetAxis ("Horizontal");
			this._jump = Input.GetAxis ("Vertical");

			if (this._move != 0) {
				if (this._move > 0) {
					// movement force
					if (absVelX < this.velocityRange.max) {
						forceX = this.moveForce;
					}
					this._facialRight = true;
					this._flip ();
				}
				if (this._move < 0) {
					//movement force
					if (absVelX < this.velocityRange.max) {
						forceX = -this.moveForce;
					}
					this._facialRight = false;
					this._flip ();
				}

				this._animator.SetInteger ("Anim_State", 1);
			} else {
				this._animator.SetInteger ("Anim_State", 0);
			}


			if (this._jump > 0) {
				// jump clip
				this._animator.SetInteger ("Anim_State", 2);
				if (absVelY < this.velocityRange.max) {
					forceY = this.jumpForce;
				}
			}
		} else {
			// jump clip
			this._animator.SetInteger ("Anim_State", 2);
		}

		Debug.Log (forceX);
		Debug.Log (forceY);
		// apply forces to the player
		this._rigidBody2D.AddForce (new Vector2 (forceX, forceY));
	}


	private void _flip() {
		if(this._facialRight) {
			this._transform.localScale = new Vector2 (1, 1);
		} else {
			this._transform.localScale = new Vector2 (-1, 1);
		}
	} 
}