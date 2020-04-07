using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IF_SkillDamageOverTime : IF_SkillDuration, IF_SkillDamage
{
    int StackLimit { get; set; }
    bool Refreshable { get; set; }
    bool RefreshDuration();
}
