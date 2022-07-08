using UnityEngine;

namespace AsteroidsAssembly.TransformLogic
{
    public interface IMovementBehaviour
    {
        Vector2 GetNextPosition();
        Vector3 GetNextRotation(Vector3 curRotation);
    }
}