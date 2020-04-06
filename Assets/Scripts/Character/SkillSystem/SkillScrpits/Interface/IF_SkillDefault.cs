using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SkillDefault {
    string toString();
    string Name { get; set; }
    string SkillText { get; set; }

    event EventHandler Activate;
    event EventHandler Extinct;
    
    event EventHandler OnKill_Trigger;
    event EventHandler OnCritStrike_Tirgger;
    event EventHandler OnHit_Trigger;
    event EventHandler OnDamageTaken_Trigger;

    event EventHandler SKillChain_Trigger;

    Coroutine Channelling();
    Coroutine CoolDown();
}
