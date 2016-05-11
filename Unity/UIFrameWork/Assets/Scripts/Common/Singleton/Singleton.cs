using System;

namespace UIFrameWork
{
	public abstract class Singleton<T> where T : class, new()
	{
		protected static T _instance;
		public static T Instance
		{
			get
			{ 
				if (null == _instance) 
				{
					_instance = new T ();
				}
				return _instance;
			}
		}

		protected Singleton()
		{
			if (null != _instance) 
			{
				throw new SingletonException ("This " + typeof(T).ToString() + "Singleto Instance is not null");
				//throw new SingletonException ("Singleto Instance is not null");
			}
			Init ();
		}

		protected virtual void Init() { }
	}
}

