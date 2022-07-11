using UnityEngine;

namespace AsteroidsAssembly.LifecycleLogic
{
    public interface ILifecycleViewer
    {
        void SetEnable(bool isEnabled);
        void EndLifecycle(int endScore);
        void EndLifecycle(int endScore, Vector3 hitDirection);
    }
}