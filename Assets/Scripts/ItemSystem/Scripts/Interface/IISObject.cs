using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISObject
    {
        //name
        //value - gold value
        //icon
        //burden
        //qualityLevel
        string Name { get; set; }
        int Value { get; set; }
        Sprite Icon { get; set; }

        int Burden { get; set; }

        ISQuality Quality { get; set; }

        //these got to other item interfaces.
        //equip
        //questitem flag
        //durabuility
        //takedamage
        //prefab
    }
}