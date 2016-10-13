﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Required to use Lists or Dictionaries

public class Main : MonoBehaviour {
	static public Main S;
	public GameObject[] prefabEnemies;
	public float enemySpawnPerSecond = 0.5f; // # Enemies/second
	public float enemySpawnPadding = 1.5f; // Padding for position
	public bool ________________;

	public float enemySpawnRate; // Delay between Enemy spawns

	void Awake() {
		S = this;
		// Set Utils.camBounds
		Utils.SetCameraBounds(this.GetComponent<Camera>());
		// 0.5 enemies/second = enemySpawnRate of 2
		enemySpawnRate = 1f/enemySpawnPerSecond; // 1
		// Invoke call SpawnEnemy() once after a 2 second delay
		Invoke( "SpawnEnemy", enemySpawnRate ); // 2
	}

	public void SpawnEnemy() {
		// Pick a random Enemy prefab to instantiate
		int ndx = Random.Range(0, prefabEnemies.Length);
		GameObject go = Instantiate( prefabEnemies[ ndx ] ) as GameObject;
		// Position the Enemy above the screen with a random x position
		Vector3 pos = Vector3.zero;
		float xMin = Utils.camBounds.min.x+enemySpawnPadding;
		float xMax = Utils.camBounds.max.x-enemySpawnPadding;
		pos.x = Random.Range( xMin, xMax );
		pos.y = Utils.camBounds.max.y + enemySpawnPadding;
		go.transform.position = pos;
		// Call SpawnEnemy() again in a couple of seconds
		Invoke( "SpawnEnemy", enemySpawnRate ); // 3
	}
}
