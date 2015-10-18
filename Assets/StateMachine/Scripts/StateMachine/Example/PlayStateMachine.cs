using UnityEngine;
using System.Collections;
using HardGames.StateMachine;

public class HungryState: FiniteState {

	float totalTime;
	public override void OnEnter (object target) {
		totalTime = 0;
		Debug.Log("I'm Hungry!");
	}

	public override void OnUpdate (object target) {
		totalTime += Time.deltaTime;
		if (totalTime >= 1f){
			Animal animal = target as Animal;
			if (animal != null){
				Debug.Log("Time " + Time.time + ", total time " + totalTime);
				animal.Cry();
			}
			totalTime = 0;
		}
	}
}

public class FullState: FiniteState {

	float totalTime;
	public override void OnEnter (object target) {
		totalTime = 0;
		Debug.Log("I'm full!");
	}
	
	public override void OnUpdate (object target) {
		totalTime += Time.deltaTime;
		if (totalTime >= 2f){
			Animal animal = target as Animal;
			if (animal != null){
				Debug.Log("Time " + Time.time + ", total time " + totalTime + ", I want some sport!" );
			}
			totalTime = 0;
		}
	}
}

public class Animal {
	public virtual void Cry(){
	}
}

public class PlayStateMachine : FiniteStateMachine {

	// simple state machine
	protected override void Init () {

		target = new Cat();

		HungryState hungry = new HungryState();
		AddState(hungry);

		FullState full = new FullState();
		AddState(full);

		defaultState = hungry;

		AddTransition(new FiniteStateTransition("give_food", "HungryState", "FullState"));
		AddTransition(new FiniteStateTransition("run", "FullState", "HungryState"));
	}
}

