using AsteroidsAssembly.UserInterface;
using UnityEngine;

namespace AsteroidsAssembly.Entities
{
    public class UIShipEntity : MonoBehaviour
    {
        [field: SerializeField] 
        public ShipInfoContainer _shipInfoContainer { get; private set; }
    }
}