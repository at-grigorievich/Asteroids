namespace AsteroidsAssembly.LifecycleLogic
{
    public interface ILifecycleViewer
    {
        void SetEnable(bool isEnabled);
        void EndLifecycle(int endScore);
    }
}