using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IF_SkillToggle
{
    bool isOn { get; set; }
    void ToggleOn();
    void ToggleOff();
}