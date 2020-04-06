using UnityEngine;
using System.Collections;

namespace ItemSystem
{
    public interface IISStackable 
    {
        int MaxStack { get; }
        int StackSize(int amount);  //default : 0
    }
}