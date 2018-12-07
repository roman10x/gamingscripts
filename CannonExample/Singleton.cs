using UnityEngine;


namespace EngiGamesTools
{
    /// <summary>
    /// Singleton class for Unity Controllers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
    {
        static T ms_instance;

        private static bool m_applicationIsQuitting = false;

        /// <summary>
        /// returns singleton instance
        /// </summary>
        /// <returns></returns>
        public static T GetInstance()
        {
            if (m_applicationIsQuitting) { return null; }
            if (ms_instance == null)
            {
                GameObject singleton = new GameObject();
                ms_instance = singleton.AddComponent<T>();
                singleton.name = "[singleton] " + typeof(T).ToString();
            }
            return ms_instance;
        }

        /// <summary>
        /// Protected constructor for base class
        /// </summary>
        protected Singleton()
        {
        }

        private void Awake()
        {
            if (ms_instance != null && ms_instance != gameObject)
            {
                Destroy(gameObject);
            }
            else
            {
                ms_instance = (T)(object)this;
                DontDestroyOnLoad(gameObject);
            }
            Initialize();
        }
        /// <summary>
        /// Initialization override
        /// </summary>
        public virtual void Initialize() { }

        private void OnApplicationQuit()
        {
            m_applicationIsQuitting = true;
        }
    }
}
