// ********************************************
// * Source file : GameController.cs          *
// * Author name : Yaroslav Kabanov           *
// * Last Modified by : Yaroslav Kabanov      *
// * Last Date Modified : February 29th, 2016 *
// * Program Description : 2D Ninja platformer*
// * Version: 1.0                             *
// ********************************************    
// Git Rero: https://github.com/YaroslavKabanov/comp305-assignment2-2dplatformer-kabanov.git

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//private variables

	private int _scoreValue;
	private int _liveValue;
	private Animator _animator;



	// public variables 
	public Text ScoreLabel;
	public Text LivesLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Button RestartButton; 
	public Text WinLabel;



	// public methods
	public int ScoreValue {
		get {
			return _scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score : " + this._scoreValue; 

		}
	}

	public int LivesValue {
		get {
			return _liveValue;
		}

		set {
			this._liveValue = value;

			if (this._liveValue <= 0) {
				this._endGame ();
			} else {
				this.LivesLabel.text = "Lives : " + this._liveValue;
			}
		}
	}
		

	// Use this for initialization
	void Start () {
		this._initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	// initialization 
	private void _initialize () {
		this._liveValue = 3   ;
		this._scoreValue = 0;
		this.GameOverLabel.gameObject.SetActive (false);
		this.HighScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);
		this.WinLabel.gameObject.SetActive (false);
		this.ScoreLabel.gameObject.SetActive (true);
		this.LivesLabel.gameObject.SetActive (true);


	}

	// end game methods 
	private void _endGame () {
		this.HighScoreLabel.text = "High Score: " + this._scoreValue;
		this.GameOverLabel.gameObject.SetActive (true);
		this.HighScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);
		this.ScoreLabel.gameObject.SetActive (false);
		this.LivesLabel.gameObject.SetActive (false);



	}

	public void RestartButtonClick () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}