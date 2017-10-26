public class RepeatTimer
{
    private float _elaspedTime = 0;
    private float _limitTime = 0;
    private bool _isPaused = false;

    private System.Action _onTriggered;

    public RepeatTimer(float limitTime, System.Action callback)
    {
        _limitTime = limitTime;
        _onTriggered = callback;
    }

    public void Tick(float delta)
    {
        if (_isPaused)
            return;

        _elaspedTime += delta;
        if (_elaspedTime >= _limitTime)
        {
            _elaspedTime = 0;
            if (_onTriggered != null)
                _onTriggered();
        }
    }

    public void SetInterval(float limitTime)
    {
        _limitTime = limitTime;
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Resume()
    {
        _isPaused = false;
    }
}
