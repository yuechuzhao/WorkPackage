using UnityEngine;
using System.Collections;

public class TestPlayStateMachine : MonoBehaviour {
	public PlayStateMachine StateMachine;

	void OnGUI(){
		if (GUI.Button(new Rect(0, 0, 120, 30), "give food ")){
			Debug.Log("StateMachine, send event give food!");
			StateMachine.SendEvent("give_food");
		}

		if (GUI.Button(new Rect(0, 40, 120, 30), "run ")){
			Debug.Log("StateMachine, send event run!");
			StateMachine.SendEvent("run");
		}
	}
}

