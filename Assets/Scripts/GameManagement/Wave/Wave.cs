using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 한 웨이브에 대한 클래스
/// </summary>
public class Wave
{
    // 생성 될 몬스터 리스트
    public List<WaveMember> memberList;

    // 웨이브 내 몬스터 생성시 카운터 증가
    public int count;

    //웨이브 INDEX
    public int waveNumber;

    public Wave()
    {
        memberList = new List<WaveMember>();
        count = 0;
        waveNumber = 0;
        AddWaveMember(new WaveMember("CubeEnemy", 10, new Vector3(0, 0, 0)));
    }

 // Getter Setter //
    public string GetNameByCounter()
    {
        return memberList[count].name;
    }
    public int GetAmountByCounter()
    {
        return memberList[count].amount;
    }
    public Vector3 GetLocationByCounter()
    {
        return memberList[count].location;
    }
    public WaveMember GetWaveMemberByCounter()
    {
        return memberList[count];
    }

    // 웨이브에 웨이브 맴버 추가
    public void AddWaveMember(WaveMember wm)
    {
        memberList.Add(wm);
    }

    //다음 맴버가 있는지 리턴
    public bool IsNext()
    {
        //다음 waveMemeber가 있는지 여부 리턴
        return (count < memberList.Count);
    }

    public string Debug()
    {
        string s = "";
        for (int i = 0; i < memberList.Count; i++)
            s += memberList[i].name + " "+memberList[i].amount;

        return s;
    }
    
    // 웨이브의 다음 맴버를 부르기 위한 카운터
    public bool IncreaseCount()
    {
        // counter를 증가시킴
        if (IsNext())
            count++;
        else
            return false;
        return true;
    }

}
