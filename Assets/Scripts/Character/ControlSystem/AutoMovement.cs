using UnityEngine;
using System.Collections;

public class AutoMovement : MonoBehaviour
{
    //필요 없어보임
	//public static CharacterController characterController;

    // 상수 스텟 인덱스
    public readonly int
        INDEX_MOVE_SPEED = (int)IndexEnumList.StatNames.moveSpeed,
        INDEX_ROTATION_SPEED = (int)IndexEnumList.StatNames.rotationSpeed,
        INDEX_ATTACK_SPEED = (int)IndexEnumList.StatNames.attackSpeed,
        INDEX_ATTACK_RANGE = (int)IndexEnumList.StatNames.attackRange,
        INDEX_DETECT_RANGE = (int)IndexEnumList.StatNames.detectRange;
                        
                        
    public CharacterStat _moveSpeed;
    public CharacterStat _rotationSpeed;
    public CharacterStat _detectRange;

    	
	public float minDistance;   // 정지거리
    public float coolDown;  // 어택타이머
    public float minRange;  // 최소사정거리

	public bool isIdle;
    public bool isMoving;

    TargettingManager targets;
	public GameObject target = null;

    Vector3 targetPosition;
    UnityEngine.AI.NavMeshAgent agent;

    // Use this for initialization
    void Awake()
    {   Initailize();   }

    void Start()
    {
        //필요 스텟 참조
        InitailizeRefernce();
    }

    // 참조 필요한 객체 참조(Called by Start())
    void InitailizeRefernce()
    {
        StatManager tempStatManager = GetComponent<StatManager>();
        _moveSpeed = tempStatManager.CurrentStats[INDEX_MOVE_SPEED];
        _rotationSpeed = tempStatManager.CurrentStats[INDEX_ROTATION_SPEED];

        targets = GetComponent<TargettingManager>();
        target = targets.selectedTarget;
        // 타겟 배열이 존재 할 시 0번 타겟 선택
/*
        if (targets != null)
            target = targets[0];
*/
    }

    // 할당 초기화(for Awake)
	void Initailize ()
	{
		//characterController = GetComponent<CharacterController>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		isIdle = false;
        isMoving = false;
	}

    // Update is called once per frame
    void Update ()
	{
        if (!isIdle && targets!=null&& targets.selectedTarget!=null){
            //회전 할 방향을 설정
			Vector3 dir = targets.selectedTarget.transform.position - transform.position;
			Vector3 dirXZ = new Vector3 (dir.x, 0f, dir.z); //y축 이동 무시(0f)

			//Rotati{
			if (dirXZ != Vector3.zero) {
				Quaternion targetRot = Quaternion.LookRotation (dirXZ);
				Quaternion frameRot = Quaternion.RotateTowards (
						                    transform.rotation,
						                    targetRot,
						                    _rotationSpeed._value * Time.deltaTime);

				transform.rotation = frameRot;
			}
			

		//Moving{
            isMoving = true;
            Vector3 targetPos = transform.position + dirXZ;
            agent.SetDestination(targetPos);    //목표 거리 설정
            agent.stoppingDistance = minRange;  //정지거리 설정
           
        }
	}
}
