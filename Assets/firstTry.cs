using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstTry : MonoBehaviour {

	// Use this for initialization
	private int turn;
	private int[ , ] state = new int[3,3];
	// Use this for initialization
	void reset()
	{
		turn = 1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				state [i, j] = 0;
			}
		}
	}
	void Start () {
		reset ();
	}
	int check()
	{
		for (int i = 0; i < 3; i++) {
			if (state [i, 0] != 0 && state [i, 0] == state [i, 1] && state [i, 1] == state [i, 2])
				return state [i, 0];
		}
		for (int i = 0; i < 3; i++) {
			if (state [0, i] != 0 && state [0, i] == state [1, i] && state [1, i] == state [2, i])
				return state [0, i];
		}
		int flag = state [0, 0];
		int flag2 = state [0, 2];
		for (int i = 0; i < 3; i++) {
			if (state [i, i] != flag && state [i, 2 - i] != flag2)
				return 0;
		}
		if (flag == state [2, 2])
			return flag;
		else
			return flag2;
	}
	void OnGUI()
	{
		GUI.Box(new Rect(596, 100, 160, 350), "");
		GUIStyle style = new GUIStyle ();
		style.normal.textColor = new Color (46f / 256f, 163f / 256f, 256f / 256f);
		style.fontSize = 24;
		if (GUI.Button (new Rect (625, 380, 100, 50), "reset")) {
			reset ();
		}
		int result = check ();
		if (result == 1) {
			GUI.Label (new Rect (630, 300, 100, 50), "O win!!!", style);
		} else if (result == 2) {
			GUI.Label (new Rect (630, 300, 100, 50), "X win!!!", style);
		}
		int flag = 0;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (state [i, j] == 0)
					flag = 1;
			}
		}
		if (flag == 0) {
			GUI.Label (new Rect (650, 300, 100, 50), "平局", style);
		}
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (state [i, j] == 1) {
					GUI.Button (new Rect (i * 50+600, j * 50+100, 50, 50), "O");
				}
				if (state [i, j] == 2) {
					GUI.Button (new Rect (i * 50+600, j * 50+100, 50, 50), "X");
				}
				if (GUI.Button (new Rect (i * 50+600, j * 50+100, 50, 50), "")) {
					if (result == 0) {
						if (turn == 1)
							state [i, j] = 1;
						else
							state [i, j] = 2;
						turn = -turn;
					}
				}
			}
		}
	}

}
