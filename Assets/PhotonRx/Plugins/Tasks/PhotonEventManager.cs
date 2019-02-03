﻿using UnityEngine;
#if ( NET_4_6 || NET_STANDARD_2_0)
namespace PhotonRx
{
    public class PhotonEventManager : MonoBehaviour
    {
        #region static

        static PhotonEventManager instance;
        static bool initialized;

        public static bool IsInitialized
        {
            get { return initialized && instance != null; }
        }

        public static PhotonEventManager Instance
        {
            get
            {
                Initialize();
                return instance;
            }
        }

        public static void Initialize()
        {
            if (!initialized)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return;
                }
#endif
                var manager = GameObject.FindObjectOfType<PhotonEventManager>();

                if (manager == null)
                {
                    var go = new GameObject("PhotonEventManager");
                    manager = go.AddComponent<PhotonEventManager>();
                }

                instance = manager;
                initialized = true;
            }
        }
        #endregion

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
#endif