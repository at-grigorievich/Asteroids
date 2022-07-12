using UnityEngine;

namespace AsteroidsAssembly
{
    public static class OutFromRectChecker
    {
        public static void CheckOutFromRect(Transform transform, Camera camera,
            ref Vector3 nextPosition)
        {
            Vector2 viewportPoint = camera.WorldToViewportPoint(
                transform.position+transform.up*transform.localScale.y/2f);

            bool isFlippedX = NeedToFlip(viewportPoint.x);
            bool isFlippedY = NeedToFlip(viewportPoint.y);
            
            if (isFlippedX)
                nextPosition.x *= -1f;

            if (isFlippedY)
                nextPosition.y *= -1f;

            bool NeedToFlip(float value) => value > 1f || value < -0f;
        }
    }
}