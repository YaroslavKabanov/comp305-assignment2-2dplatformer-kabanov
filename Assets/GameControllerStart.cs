// ********************************************
// * Source file : GameControllerStart.ts        *
// * Author name : Yaroslav Kabanov           *
// * Last Modified by : Yaroslav Kabanov      *
// * Last Date Modified : February 29th, 2016 *
// * Program Description : 2D Ninja platformer*
// * Version: 1.0                             *
// ********************************************    
// Git Rero: https://github.com/YaroslavKabanov/comp305-assignment2-2dplatformer-kabanov.git

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// start new game after start button being clicked
	public void LoadGame () {
		SceneManager.LoadScene ("Main");
	}
}
