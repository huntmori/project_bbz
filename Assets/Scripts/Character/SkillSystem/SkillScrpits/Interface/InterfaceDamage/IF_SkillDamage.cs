using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IF_SkillDamage
{
    float Damage { set; get; }
    IndexEnumList.DamageType DmgType { get; set; }
}