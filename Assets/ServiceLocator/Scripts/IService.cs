using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorDemo
{
    public interface IService
    {
        void OnRegister();
        void OnDeregister();
    }
}