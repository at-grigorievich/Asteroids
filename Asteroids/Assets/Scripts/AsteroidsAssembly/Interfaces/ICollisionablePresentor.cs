using UnityEngine;

namespace AsteroidsAssembly.Interfaces
{
    public interface ICollisionablePresentor: IEnable
    {
        void StartCollision(Collision2D collision);
    }
}