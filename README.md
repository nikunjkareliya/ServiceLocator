
# Service Locator Design Pattern in Unity

Provide a global point of access to a service without coupling users to the concrete class that implements it. 





## Features

- The Service Locator pattern is a design pattern used in software development to provide a centralized point of access to services throughout an application without coupling the classes to specific implementations.
- This pattern uses a central registry known as the "service locator", which on request returns the information necessary to perform a certain task


## Usage/Examples

```cs
public class Bootstrapper: MonoBehaviour 
{
    [SerializeField] private AudioService _audioService;

    private void Awake() 
    {
        Debug.Log("<b>Bootstrapper is Initialized!</b>");

        // Initialize default service locator.
        ServiceLocator.Initiailze();

        ServiceLocator.Current.Register<IAudioService>(_audioService);
        // Register other services. . 
        .
        .
        .
        etc.
    }

    private void OnDestroy() 
    {
        ServiceLocator.Current.Unregister<IAudioService>();
    }
}
```

## How to use it?
```cs
IAudioService audio = ServiceLocator.Current.Get<IAudioService>();
audio.PlayClip(123456);
```
```cs
public interface IService
{
    void OnRegister();
    void OnDeregister();
}

public interface IAudioService : IService
{
    float GetVolume();
    void SetVolume(float volume);

    void PlayClip(int clipID);

    void Pause();
    void Resume();
}

public class ServiceLocator 
{
    private ServiceLocator() 
    {
    }
    
    private readonly Dictionary < string, IService > services = new Dictionary < string, IService > ();
    
    public static ServiceLocator Current 
    {
        get;
        private set;
    }
    
    // Initializes the service locator with a new instance.    
    public static void Initiailze() 
    {
        Current = new ServiceLocator();
    }
    
    // Gets the service instance of the given type.    
    public T Get <T> () where T: IService 
    {
        string key = typeof (T).Name;
        if (!services.ContainsKey(key)) 
        {
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }

        return (T) services[key];
    }
    
    // Registers the service with the current service locator.    
    public void Register <T> (T service) where T: IService 
    {
        string key = typeof (T).Name;
        if (services.ContainsKey(key)) 
        {
            Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
            return;
        }

        services.Add(key, service);
    }
    
    // Unregisters the service from the current service locator.    
    public void Unregister <T> () where T: IService 
    {
        string key = typeof (T).Name;
        if (!services.ContainsKey(key)) 
        {
            Debug.LogError($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
            return;
        }

        services.Remove(key);
    }
}

```


## Screenshots

[![Capture2.png](https://i.postimg.cc/43RyR813/Capture2.png)](https://postimg.cc/CRJSjsXy)
## 🔗 References
[gameprogrammingpatterns.com/service-locator.html](https://gameprogrammingpatterns.com/service-locator.html)

