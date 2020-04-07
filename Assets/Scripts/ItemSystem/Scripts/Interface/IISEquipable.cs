using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISEquipable
    {
        ISEquipmentSlot EquipmentSlot { get; }
        bool Equip();

    }
}
