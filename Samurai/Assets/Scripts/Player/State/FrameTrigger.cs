public class FrameTrigger
{
    private float _lastFrame;
    public bool Passed(float currentFrame, float triggerFrame)
    {
        bool fired = (_lastFrame < triggerFrame && currentFrame >= triggerFrame);
        _lastFrame = currentFrame;
        return fired;
    }
    public void Reset()
    {
        _lastFrame = 0;
    }
}
