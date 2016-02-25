using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//private variables

	private int _scoreValue;
	private int _liveValue;



	// public variables 
	public Text ScoreLabel;
	public Text LivesLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Button RestartButton; 



	// public methods
	public int ScoreValue {
		get {
			return _scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue; 

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
				this.LivesLabel.text = "Lives: " + this._liveValue;
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
		
	
	private void _initialize () {
		this._liveValue = 3   ;
		this._scoreValue = 0;
		this.GameOverLabel.gameObject.SetActive (false);
		this.HighScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive (false);
	}

	private void _endGame () {
		this.HighScoreLabel.text = "High Score: " + this._scoreValue;
		this.GameOverLabel.gameObject.SetActive (true);
		this.HighScoreLabel.gameObject.SetActive (true);
		this.RestartButton.gameObject.SetActive (true);


}
