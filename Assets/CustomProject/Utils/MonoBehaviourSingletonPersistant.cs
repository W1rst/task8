
using UnityEngine;

namespace CustomProject.Utils
{
    public class MonoBehaviourSingletonPersistent<T> : MonoBehaviour
        where T : Component
    {
        public static T Instance { get; private set; }
	
        private void Awake()
        {
            if (Instance == null) 
            {
                Instance = this as T;
                DontDestroyOnLoad (this);
                OnSingletonInitialized();
            } 
            else 
            {
                Destroy (this);
            }
        }

        protected virtual void OnSingletonInitialized()
        {
            
        }
    }
}