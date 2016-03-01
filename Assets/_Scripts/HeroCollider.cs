// ********************************************
// * Source file : HeroCollider.cs            *
// * Author name : Yaroslav Kabanov           *
// * Last Modified by : Yaroslav Kabanov      *
// * Last Date Modified : February 29th, 2016 *
// * Program Description : 2D Ninja platformer*
// * Version: 1.0                             *
// ********************************************    
// Git Rero: https://github.com/YaroslavKabanov/comp305-assignment2-2dplatformer-kabanov.git

using UnityEngine;
using System.Collections;

public class HeroCollider : MonoBehaviour {

	// private variables
	private AudioSource[] _audioSources;
	private AudioSource _finishGameSound;
	private AudioSource _diamondCollectSound;
	private AudioSource _hitCactusSound;


	// public variables 
	public GameController gameController;

	// Use this for initialization
	void Start () {
	
		this._audioSources = gameObject.GetComponents<AudioSource> ();
		this._finishGameSound = this._audioSources [2];
		this._diamondCollectSound = this._audioSources [3];
		this._hitCactusSound = this._audioSources [5];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		// collision with diamond object
		if (other.gameObject.CompareTag ("Diamond")) {
			this._diamondCollectSound.Play ();
			Destroy (other.gameObject);
			this.gameController.ScoreValue += 100;
		}

		//enemy collision 

		if (other.gameObject.CompareTag ("Enemy")) {
			this.gameController.LivesValue -= 1;
			this._hitCactusSound.Play ();
		}
		// collision with finish object
		if (other.gameObject.CompareTag ("Finish")) {
			this._finishGameSound.Play ();
			this.gameController.WinLabel.gameObject.SetActive (true);
			this.gameController.RestartButton.gameObject.SetActive (true);

		}
	}


}
