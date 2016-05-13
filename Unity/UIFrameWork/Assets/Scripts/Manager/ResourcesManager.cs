using System;
using UnityEngine;
using System.Collections.Generic;

namespace UIFrameWork
{
    #region AssetInfo
    public class AssetInfo
	{
		private UnityEngine.Object mObject;
		public Type AssetType { get; set; }
		public string Path { get; set; }
		public int RefCount { get; set; }

		public bool IsLoaded
		{
			get
			{ 
				return null != mObject;
			}
		}

		public UnityEngine.Object AssetObject
		{
			get
			{ 
				if (null == mObject) 
				{
					ResourceLoad();
				}
				return mObject;
			}
		}

		private void ResourceLoad()
		{
			try
			{
				mObject = Resources.Load (Path);
				if (null == mObject) 
				{
					//Debug.Log ("Resource Load Failure! path : " + Path);
				}
			}
			catch(Exception e) 
			{
				//Debug.Log (e.ToString());
			}
		}

        public IEnumerator<UnityEngine.Object> GetCoroutineObject(Action<UnityEngine.Object> _loaded)
		{
			while (true) 
			{
                yield return null;
				if (null == mObject) 
				{
					ResourceLoad();
					yield return null;
				}
                if (null != _loaded)
                {
                    _loaded(mObject);
                }
				yield break;
			}
		}

        public IEnumerator<float> GetAsyncObject(Action<UnityEngine.Object> _loaded)
		{
			yield return 0;
			GetAsyncObject (_loaded, null);
		}

        public IEnumerator<UnityEngine.Object> GetAsyncObject(Action<UnityEngine.Object> _loaded, Action<float> _progress)
		{
			if (null != mObject) 
			{
				_loaded (mObject);
				yield break;
			} 

			ResourceRequest resRequest = Resources.LoadAsync (Path);
			while (resRequest.progress < 0.9)
			{
				if (null != _progress) 
				{
					_progress (resRequest.progress);
				}
				yield return null;
			}

			while (! resRequest.isDone) 
			{
				if (null != _progress) 
				{
					_progress (resRequest.progress);
				}
				yield return null;
			}
			mObject = resRequest.asset;
			if (null != _loaded) 
			{
				_loaded (mObject);
			}
			//yield return resRequest;
            yield return null;
		}
	}
    #endregion

    public class ResourcesManager : Singleton<ResourcesManager>
	{
		private Dictionary<string, AssetInfo> dictAssetInfo = null;
		protected override void Init ()
		{
			base.Init ();
            dictAssetInfo = new Dictionary<string, AssetInfo>();
		}

        #region Load Resources && Instantiate Object
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public UnityEngine.Object LoadInstance(string _path)
        {
            UnityEngine.Object uObject = Load(_path);
            return Instantiate(uObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_loaded"></param>
        public void LoadCoroutineInstance(string _path, Action<UnityEngine.Object> _loaded)
        {
            LoadCoroutine(_path, (_obj) => {
                Instantiate(_obj, _loaded);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_loaded"></param>
        public void LoadAsyncInstance(string _path, Action<UnityEngine.Object> _loaded)
        {
            //LoadAsync(_path, (_obj) => {
            //    LoadAsync(_path, _loaded);
            //});
            LoadAsyncInstance(_path, _loaded, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_loaded"></param>
        /// <param name="_progress"></param>
        public void LoadAsyncInstance(string _path, Action<UnityEngine.Object> _loaded, Action<float> _progress)
        {
            LoadAsync(_path, (_obj) => {
                //LoadAsync(_path, _loaded);
                Instantiate(_obj, _loaded);
            }, _progress);
        }
        #endregion

        #region Load Resource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public UnityEngine.Object Load(string _path)
        {
            AssetInfo assetInfo = GetAssetInfo(_path);
            if (null != assetInfo)
            {
                return assetInfo.AssetObject;
            }
            return null;
        }
        #endregion

        #region Load Coroutine Resources
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_loaded"></param>
        public void LoadCoroutine(string _path, Action<UnityEngine.Object> _loaded)
        {
            AssetInfo assetInfo = GetAssetInfo(_path);
            if (null != assetInfo)
            {
                CoroutineController.Instance.StartCoroutine(assetInfo.GetCoroutineObject(_loaded));
            }
        }
        #endregion

        #region Load Async Resources

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_Loaded"></param>
        public void LoadAsync(string _path, Action<UnityEngine.Object> _Loaded)
        {
            LoadAsync(_path, _Loaded, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_loaded"></param>
        /// <param name="_progress"></param>
        public void LoadAsync(string _path, Action<UnityEngine.Object> _loaded, Action<float> _progress)
        {
            AssetInfo assetInfo = GetAssetInfo(_path, _loaded);
            if (null != assetInfo)
            {
                CoroutineController.Instance.StartCoroutine(assetInfo.GetAsyncObject(_loaded, _progress));
            }
        }

        #endregion

        #region Get AssetInfo && Instantiate

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        private AssetInfo GetAssetInfo(string _path)
        {
            return GetAssetInfo(_path, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_loaded"></param>
        /// <returns></returns>
        private AssetInfo GetAssetInfo(string _path, Action<UnityEngine.Object> _loaded)
        {
            if (string.IsNullOrEmpty(_path))
            {
                if (null != _loaded)
                {
                    _loaded(null);
                }
            }
            AssetInfo assetInfo = null;
            if (!dictAssetInfo.TryGetValue(_path, out assetInfo))
            {
                assetInfo = new AssetInfo();
                assetInfo.Path = _path;
                dictAssetInfo.Add(_path, assetInfo);
            }
            assetInfo.RefCount++;

            return assetInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        private UnityEngine.Object Instantiate(UnityEngine.Object _obj)
        {
            return Instantiate(_obj, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_obj"></param>
        /// <param name="_loaded"></param>
        /// <returns></returns>
        private UnityEngine.Object Instantiate(UnityEngine.Object _obj, Action<UnityEngine.Object> _loaded)
        {
            UnityEngine.Object retObj = null;
            if (null != _obj)
            {
                retObj = MonoBehaviour.Instantiate(_obj);
                if (null != retObj)
                {
                    if (null != _loaded)
                    {
                        _loaded(retObj);
                    }
                    else
                    {
                        //Debug.Log("Error: _loaded is null");
                    }
                }
                else
                {
                    //Debug.LogError("Error: Instantiate Object return null");
                }
            }
            else
            {

            }
            return retObj;
        }

        #endregion
    }
}