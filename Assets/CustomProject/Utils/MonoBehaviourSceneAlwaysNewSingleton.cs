
using UnityEngine;

namespace CustomProject.Utils
{
    public class MonoBehaviourSceneAlwaysNewSingleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }
	
        private void Awake()
        {
            if (Instance != null) 
            {
                Destroy(Instance);
                
            } 
            Instance = this as T;
            OnSingletonInitialized();
        }

        protected virtual void OnSingletonInitialized()
        {
            
        }
    }
}