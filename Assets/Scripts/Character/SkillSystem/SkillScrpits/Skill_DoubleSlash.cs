using UnityEngine;
using System.Collections;
using System;

public class Skill_DoubleSlash : MonoBehaviour
{
    string _skillName;
    string _text;

    int _costValue;
    int _skillID;
    int _damage;
    int _radius;

    float _range;
    float _coolDown;

    bool _isMelee;
    bool _isSplash;
    bool _isSelfTarget;
    bool _isTargetEnemy;
    bool _isTargetPlayer;
    bool _isTargetNonPlayer;

    public bool DEBUG_MOD = false;

    Sprite _icon;
    AutoAttack _autoAttack;

    public void Attack()
    {
        // 최초 참조를 생성자에서(혹은 Start함수) 해야 할 필요가 잇어보임. 이 코드로는 매 공격시 마다 재참조.
        if(_autoAttack==null)
        {
            _autoAttack = GetComponentInParent<AutoAttack>() as AutoAttack;
        }

        //공격 두번 실행
        _autoAttack.Attack();
        _autoAttack.Attack();

        //공격 쿨다운 초기화
        _autoAttack._coolDown = _autoAttack._attackSpeed._value;

        if(DEBUG_MOD)
            Debug.Log("DoubleSlash!");
    }




    public void SkillCoolDown()
    {
        throw new NotImplementedException();
    }

}
