using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface BuffBase
{
    
    // 증감 대상 스텟 INDEX
    int TargetStat { get; set; }

    //지속시간
    float Duration { get; set; }

    //남은시간. 
    float RemainTime { get; set; }

    //버프 시작시간
    float StartTime { get; set; }

    //버프 증감값.
    float BuffValue { set; get; }

    GameObject Target { get; set; }
    // 버프에 대한 코루틴 정의
    IEnumerator BuffActivate(StatManager Target);
    IEnumerator BuffActivate();

    //툴팁에 표시 될 문자열.스킬정보표기
    string ToString();
    Event Action { set; get; }
    
}
