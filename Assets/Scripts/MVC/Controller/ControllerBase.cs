using Asteroids.Abstraction;

public abstract class ControllerBase : IController
{
    protected bool _started { get; private set; }
    
    public void Start()
    {
        if (_started) return;
        _started = true;

        OnStart();
    }

    public void ResetView()
    {
        OnViewReset();
    }

    public void Dispose()
    {
        if (!_started) return;
        _started = false;

        OnDispose();
    }

    protected abstract void OnViewReset();
    protected abstract void OnDispose();
    protected abstract void OnStart();
}