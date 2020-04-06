using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IF_SkillDuration{
    float Duration { get; set; }
    Coroutine ContinueDuration();

}
