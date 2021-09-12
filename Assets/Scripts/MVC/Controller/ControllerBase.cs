using Asteroids.Abstraction;

public abstract class ControllerBase : IController
{
    private bool _started;

    public void Start()
    {
        if (_started) return;
        _started = true;

        OnStart();
    }
    
    public void Dispose()
    {
        if (!_started) return;
        _started = false;

        OnDispose();
    }

    protected abstract void OnDispose();
    protected abstract void OnStart();
}