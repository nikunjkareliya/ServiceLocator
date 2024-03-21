using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorDemo
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        public float GetVolume()
        {
            throw new System.NotImplementedException();
        }

        public void OnDeregister()
        {
            Debug.Log($"AudioService is de-registered");
        }

        public void OnRegister()
        {
            Debug.Log($"AudioService is registered");
        }

        public void Pause()
        {
            throw new System.NotImplementedException();
        }

        public void PlayClip(int clipID)
        {
            Debug.Log($"PlayClip -> {clipID}");
        }

        public void Resume()
        {
            throw new System.NotImplementedException();
        }

        public void SetVolume(float volume)
        {
            throw new System.NotImplementedException();
        }
    }
}