using UnityEngine;
using System.Collections;

namespace HardGames.UniqueController {
	public interface IGameBehaviour{
		void Awake();
		void Start();
		void Update();
		void FixedUpdate();
		void LateUpdate();
		void OnEnable();
		void OnDisable();
		void OnDestroy();

		void OnGUI();
		void DestroySelf();
	}

	public class GameBehaviour: IGameBehaviour {

		private bool active_;

		public GameObject Target {get; set;}

		public GameBehaviour(){
			Awake();
			OnEnable();

		}

		~GameBehaviour(){
		}

		public void DestroySelf(){
			if (Target != null){
				GameObject.Destroy(Target);
			} 
			OnDestroy();
		}


		public virtual void Awake(){
		}

		public virtual void Start(){
		}

		public virtual void Update(){
		}

		public virtual void FixedUpdate(){
		}

		public virtual void LateUpdate(){
		}

		public virtual void OnGUI(){
		}

		public virtual void OnEnable(){
		}

		public virtual void OnDisable(){
		}

		public virtual void OnDestroy(){
		}

		public void SetActive(bool value){
			if (active_ == value) return;
			active_ = value;
			if (active_) 
				OnEnable();
			else 
				OnDisable();
			if (Target != null)
				Target.SetActive(value);
		}

		// TODO: lots of function not here, e.g. OnCollisionEnter. etc.
	}
}

