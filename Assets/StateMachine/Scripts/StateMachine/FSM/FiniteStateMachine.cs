using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HardGames.StateMachine {
	public class FiniteStateMachine : MonoBehaviour {

		public object target;
		protected FiniteState currentState = null;
		protected FiniteState defaultState = null;


		Dictionary<string, FiniteState> allStates;
		List<FiniteStateTransition> allTransitions;

		protected virtual void Init(){
			// override it, for initialize all state or transactions
			// set defaultState;
			// target = x;
			// AddState();
			// AddTransition();
		}

		protected void AddState(FiniteState state){
			// not allow same-name state
			// Assert(!allStates.ContainsKey(state.Name));
			allStates.Add(state.Name, state);
		}

		protected void RemoveState(FiniteState state){
			allStates.Remove(state.Name);
		}

		protected void AddTransition(FiniteStateTransition transition){
			allTransitions.Add(transition);
		}

		protected void RemoveTransition(FiniteStateTransition transition){
			allTransitions.Remove(transition);
		}

		/// <summary>
		/// Sends the event, to change transaction
		/// </summary>
		/// <param name="eventName">Event name.</param>
		public void SendEvent(string eventName){
			for (int i = 0; i < allTransitions.Count; i++) {
				FiniteState nextState;
				if (TryGetNextStateByEventName(allTransitions[i], eventName, out nextState)){
					ChangeState(nextState);
					break;
				}
			}
		}

		public void SetTarget(object target){
			this.target = target;
		}

		bool TryGetNextStateByEventName(FiniteStateTransition transation, string eventName, out FiniteState state){
			state = null;
			if (currentState == null || !currentState.Name.Equals(transation.LastStateName)) return false;
			if (!eventName.Equals(transation.EventName)) return false;
			return (allStates.TryGetValue(transation.NextStateName, out state));
		}

		void ChangeState(FiniteState newState){
			if (currentState != null){
				currentState.OnExit(target);
			}
			currentState = newState;
			// TODO Assert(currentState != null);
			currentState.OnEnter(target);
		}

		void InitCollections(){
			allStates = new Dictionary<string, FiniteState>();
			allTransitions = new List<FiniteStateTransition>();
		}

		void Awake(){
			InitCollections();
			Init();
			SetDefaultToCurrent();
		}

		void SetDefaultToCurrent(){
			currentState = defaultState;
		}

		// Use this for initialization
		void Start () {
			if (currentState != null){
				currentState.OnEnter(target);
			}		
		}

		// do state update
		void Update () {
			if (currentState != null){
				currentState.OnUpdate(target);
			}
		}

	}
}

