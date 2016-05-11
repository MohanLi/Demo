using UnityEngine;
using System.Collections;

namespace UIFrameWork
{
	public abstract class BaseUI : MonoBehaviour 
	{
		#region Cache GameObject && Transform

		private GameObject _cacheGameObject;
		/// <summary>
		/// Gets the cache game object.
		/// </summary>
		/// <value>The cache game object.</value>
		public GameObject CacheGameObject
		{
			get
			{
				if (null == _cacheGameObject) 
				{
					_cacheGameObject = this.gameObject;
				}
				return _cacheGameObject;
			}
		}

		private Transform _cacheTransform;
		/// <summary>
		/// Gets the cache transform.
		/// </summary>
		/// <value>The cache transform.</value>
		public Transform CacheTransform
		{
			get
			{ 
				if (null == _cacheTransform) 
				{
					_cacheTransform = this.transform;
				}
				return _cacheTransform;
			}
		}

		#endregion


		#region EnumObjectState && UI Type

		public event StateChangeEvent StateChange;
		protected EnumObjectState _objectState = EnumObjectState.None;

		/// <summary>
		/// Gets or sets the state of the object.
		/// </summary>
		/// <value>The state of the object.</value>
		public EnumObjectState ObjectState
		{
			protected get {
				return this._objectState;
			}
			set {
				if (this._objectState != value) {
					EnumObjectState oldState = this._objectState;
					this._objectState = value;
					StateChange(this, this._objectState, oldState);
				}
			}
		}

		public abstract EnumUIType GetUIType ();

		#endregion

		#region 系统函数
		void Awake()
		{
			this.ObjectState = EnumObjectState.Initial;
			OnAwake ();
		}

		void Start () 
		{
			OnStart ();
		}

		void Update () 
		{
			if (this.ObjectState == EnumObjectState.Ready) 
			{
				OnUpdate (Time.deltaTime);
			}
		}

		void OnDestroy()
		{
			this.ObjectState = EnumObjectState.None;
		}
		#endregion

		#region 虚函数
		protected virtual void OnAwake() 
		{
			this.ObjectState = EnumObjectState.Loading;
			this.OnPlayOpenUIAudio ();
		}
		protected virtual void OnStart() {}
		protected virtual void OnUpdate(float deltaTime) {}
		protected virtual void OnRelease()
		{
			this.ObjectState = EnumObjectState.None;
			this.OnPlayCloseUIAudio ();
		}
		protected virtual void OnLoadData() {}

		protected virtual void OnPlayOpenUIAudio() { }
		protected virtual void OnPlayCloseUIAudio() { }
		protected virtual void SetUI(params object[] uiParams) 
		{
			this.ObjectState = EnumObjectState.Loading;
		}
		protected virtual void SetUIParams(params object[] uiParams) { }

		#endregion

		public void Release()
		{
			this.ObjectState = EnumObjectState.Closing;
			GameObject.Destroy (this.CacheGameObject);
			OnRelease ();
		}



		public void SetUIWhenOpening(params object[] uiParams)
		{
			SetUI (uiParams);
			CoroutineController.Instance.StartCoroutine (LoadDatAsyn());
		}

		private IEnumerator LoadDatAsyn()
		{
			yield return new WaitForSeconds (0);
			if (this.ObjectState == EnumObjectState.Loading) {
				this.OnLoadData ();
				this.ObjectState = EnumObjectState.Ready;
			}
		}
	}
}