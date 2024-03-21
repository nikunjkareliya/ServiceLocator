using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ServiceLocatorDemo
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private AudioService _audioService;
                
        private void Awake()
        {
            Debug.Log("<b>Bootstrapper is Initialized!</b>");
            // Initialize default service locator.
            ServiceLocator.Initiailze();

            // Register all your services next.            
            //ServiceLocator.Current.Register<IMyGameServiceB>(new MyGameServiceB());
            //ServiceLocator.Current.Register<IMyGameServiceC>(new MyGameServiceC());

            ServiceLocator.Current.Register<IAudioService>(_audioService);

            // Application is ready to start, load your main scene.
            //SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }

        private void OnDestroy()
        {
            ServiceLocator.Current.Unregister<IAudioService>();
        }

        private void Update()
        {            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IAudioService audio = ServiceLocator.Current.Get<IAudioService>();
                audio.PlayClip(123456);
            }
        }
    }
}