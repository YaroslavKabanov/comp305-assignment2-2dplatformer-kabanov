using UnityEngine;
using System.Collections;

public class HeroCollider : MonoBehaviour {

	// private variables
	private AudioSource[] _audioSources;
	private AudioSource _finishGameSound;
	private AudioSource _diamondCollectSound;

	// public variables 
	public GameController gameController;

	// Use this for initialization
	void Start () {
	
		this._audioSources = gameObject.GetComponents<AudioSource> ();
		this._finishGameSound = this._audioSources [2];
		this._diamondCollectSound = this._audioSources [3];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Diamond")) {
			this._diamondCollectSound.Play ();
			Destroy (other.gameObject);
			this.gameController.ScoreValue += 100;
		}
	

		if (other.gameObject.CompareTag ("Finish")) {
			this._finishGameSound.Play ();
		}
	}


}
