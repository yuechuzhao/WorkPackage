using UnityEngine;
using System.Collections;

namespace HardGames.StateMachine{

	public class FiniteStateTarget {

	}

	public class FiniteStateTransition {
		public string EventName;
		public string LastStateName;
		public string NextStateName;

		public FiniteStateTransition(string eventName, string lastStateName, string nextStateName){
			EventName = eventName;
			LastStateName = lastStateName;
			NextStateName = nextStateName;
		}

	}

	public class FiniteState {
		public string Name {
			get {
				return GetType().Name;
			}
		}


		public virtual void OnEnter(object target){

		}

		public virtual void OnExit(object target){

		}

		public virtual void OnUpdate(object target){
			
		}

		public virtual void OnFixedUpdate(object target){
			
		}

		public virtual void OnLateUpdate(object target){
			
		}
	}
}
