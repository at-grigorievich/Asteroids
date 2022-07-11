using UnityEngine;

namespace AsteroidsAssembly.Gun_Logic.Gun_Data
{
    [CreateAssetMenu(fileName = "Gun Reloading", menuName = "Guns/New Reloading Parameters", 
        order = 0)]
    public class GunReloadingData : ScriptableObject
    {
        [field: SerializeField] public int MaxCount { get; private set; }
        [field: SerializeField] public int ReloadingDelay { get; private set; }
    }
}