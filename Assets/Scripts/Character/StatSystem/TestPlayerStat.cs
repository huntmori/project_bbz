using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerStat : MonoBehaviour {
    public float attackDamage, attackSpeed, attackRange, attackRadius,
          moveSpeed, rotationSpeed, detectRange,
          deffencePoint, currenthealth,maxHealth, healthregen, damageReduce,
          totalSkillCount, skillPoint, currentSKillResource, maxSkillResource, skillResourceRegen;

    bool Initialized = false;
    // Use this for initialization
    private void Start()
    {
        StatManager tempStat = GetComponent<StatManager>();

        tempStat.BaseStats[(int)(IndexEnumList.StatNames.attackDamage)]._value = attackDamage;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.attackSpeed]._value = attackSpeed;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.attackRange]._value = attackRange;

        tempStat.BaseStats[(int)IndexEnumList.StatNames.moveSpeed]._value = moveSpeed;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.rotationSpeed]._value = rotationSpeed;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.detectRange]._value = detectRange;

        tempStat.BaseStats[(int)IndexEnumList.StatNames.deffencePoint]._value = deffencePoint;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.currentHealth]._value = currenthealth;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.maxHealth]._value = maxHealth;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.healthRegeneration]._value = healthregen;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.damageReduce]._value = damageReduce;

        tempStat.BaseStats[(int)IndexEnumList.StatNames.totalSkillCount]._value = totalSkillCount;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.skillPoint]._value = skillPoint;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.currentSkillResource]._value = currentSKillResource;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.maxSkillResource]._value = maxSkillResource;
        tempStat.BaseStats[(int)IndexEnumList.StatNames.skillResourceRegeneration]._value = skillResourceRegen;

        Initialized = true;

    }
	
	// Update is called once per frame
	void Update () {
		if(!Initialized)
        {
            
        }
	}
}
