using UnityEngine;
using System.Collections;

public class AutoAttack : MonoBehaviour
{
    //public delegate Interface_BaseAttack BaseAttack(GameObject target, float damage);

    public GameObject project;
    public Transform fireTrans;
    public TargettingManager _targetManager;

    public bool ATTACK_BLOCK;

    public float _coolDown;
    

    public CharacterStat _attackSpeed;
    public CharacterStat _attackRange;
    public CharacterStat _attackDamage;
    
    // 상수 인덱스
    public readonly int _attackDamageIndex = (int)IndexEnumList.StatNames.attackDamage;
    public readonly int _attackRangeIndex = (int)IndexEnumList.StatNames.attackRange;
    public readonly int _attackSpeedIndex = (int)IndexEnumList.StatNames.attackSpeed;

    // Use this for initialization
    float GetMaxAttackCoolDown()
    {
        //(1.0f / _attackSpeed._value);
        return 1.0f / _attackSpeed._value;
    }

    void Awake()
    {

    }
    void Start ()
	{

        //필요 스텟참조
        StatManager _statManager = GetComponent<StatManager>();
                    _attackDamage = _statManager.CurrentStats[_attackDamageIndex];
                    _attackSpeed = _statManager.CurrentStats[_attackSpeedIndex];
                    _attackRange = _statManager.CurrentStats[_attackRangeIndex];

        _targetManager = GetComponent<TargettingManager>();

		ATTACK_BLOCK = false;

        _coolDown = 0f;
	}

    // Update is called once per frame
    void Update()
    {
        // 타겟메니저, 타겟이 없는 상태 일 시 공격불가임
        if (_targetManager == null)
            if (_targetManager.selectedTarget == null){
                return;
            }
        

        //공격 불가 상태가 아닌 경우 타이머 카운트
        if (!ATTACK_BLOCK){
            // 타이머 카운트
			if (_coolDown > 0)
				_coolDown -= Time.deltaTime;
			
            // 0보다 작아지는 경우 0으로 보정
			if (_coolDown < 0)
				_coolDown = 0;
    
			// attackTimer 가 0이면 공격을 시행, coolDown값으로 변경
			if (_coolDown == 0 && _targetManager.selectedTarget != null){
				Attack ();
			}
		}

        
        if(float.IsInfinity(_coolDown)){
            _coolDown = GetMaxAttackCoolDown();
        }
	}
	
	public void Attack()
	{
        // 타겟이 null인지를 체크
        if (_targetManager.selectedTarget != null){
            // 타겟과의 거리 구하기
            float distance = Vector3.Distance(  _targetManager.selectedTarget.transform.position,
                                                 transform.position);

            //타겟과의 방향 구하기
            Vector3 dir = (_targetManager.selectedTarget.transform.position - transform.position).normalized;
            float dircetion = Vector3.Dot(dir, transform.forward);

            // 타겟쪽으로 회전
            GetComponent<MovementManager>().LookTarget(_targetManager.selectedTarget.transform.position);

            // 공격가능거리 && 공격 가능 방향 일 시 공격 처리
            if (distance <= _attackRange._value){
                if (dircetion > 0){
                    //적이 플레이어를 공격- 미구현
                    if (this.tag == "Enemy"){
                  
                    }
                    //플레이어가 적을 공격
                    else{
                        // 투사체의 인스턴스화+목적지. 데미지설정후 쿨다운 초기화
                        GameObject proj = Instantiate(project, fireTrans.position, fireTrans.rotation);
                        proj.GetComponent<ProjectileController>().SetDestination(GetComponent<TargettingManager>().selectedTarget);
                        proj.GetComponent<ProjectileController>().SetDamage(_attackDamage._value);
                        _coolDown = GetMaxAttackCoolDown();
                        if (_targetManager.selectedTarget == null)
                            return;
                    }
                }
            }
        }
	}
}
