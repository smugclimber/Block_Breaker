﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Load level requested for:" + name);
		Application.LoadLevel(name);
	}
	public void QuitRequest(){
		Debug.Log ("I want to Quit");
		Application.Quit();
	}
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	public void brickDestroyed(){
		if(Brick.breakableCount <= 0){
		LoadNextLevel();
		}
	}	
}