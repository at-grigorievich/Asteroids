using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public interface ITransformViewer
    {
        void UpdatePosition(Vector2 nextPosition);
        void UpdateRotation(Vector3 nextRotation);
    }
}