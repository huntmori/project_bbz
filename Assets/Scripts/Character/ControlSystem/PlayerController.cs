using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class PlayerController : MonoBehaviour
{
	public TargettingManager TargetList;
    public GameObject CurrentTarget;

    public MovementManager MoveManager;
    public StatManager stats;
    public Vector3 hitPosition;

    public bool isInitialized = false,
                DEBUG_MODE = false,
                Vigilance = false;
    
    public int UI_LAYER;
    public int BLOCK_LAYER;


    //상수 인덱스
    public readonly int ATTACK_RANGE_INDEX = (int)IndexEnumList.StatNames.attackRange;
    public readonly int DETECT_RANGE_INDEX = (int)IndexEnumList.StatNames.detectRange;


    //참조초기화
    public void InitializeReference()
    {        
        TargetList = GetComponent<TargettingManager>();
        MoveManager = GetComponent<MovementManager>();
        stats = GetComponent<StatManager>();

        // 선택된 타겟을 참조
        CurrentTarget = TargetList.selectedTarget;

        //초기화-참조가 되었는지 플래그설정
        if(TargetList!=null && MoveManager!=null)
            isInitialized = true;
    }

    //초기화
    public void Initialize()
    {
        UI_LAYER = LayerMask.NameToLayer("UI");
        BLOCK_LAYER = LayerMask.NameToLayer("Block");
    }


    void Awake()
    {

    }
    void Start()
    {  
        // 참조 초기화가 안 된 경우 초기화
        if (!isInitialized){
            InitializeReference();
            isInitialized = true;
        }
        
        //클릭 이벤트 코루틴 시작
        StartCoroutine(ClickEventCoroutine());
    }
    void Update()
    {
        // 참조 초기화가 안되었을 시 초기화 실행
        if (!isInitialized){
            InitializeReference();
            isInitialized = true;
        }
            
    }

    // 마우스 동작을 입력받는 코루틴
    IEnumerator ClickEventCoroutine()
    {
        while (true){
            if (Input.GetMouseButtonUp(0)){
                // UI클릭을 block 해준다. ( ui에 이벤트가 발생하면 true를 리턴함)
                if (EventSystem.current.IsPointerOverGameObject() == false){
                    RaycastHit hitInfo;

                    //클릭 정보를 받아옴 (hitInfo)
                    if (ClickReceiver.GetClickedObject(out hitInfo)){
                        // Enemy 오브젝트 클릭
                        if (hitInfo.transform.gameObject.tag == "Enemy"){
                            if(DEBUG_MODE)
                                Debug.Log("EnemyClicked");
                            TargetList.TargetEnemy(hitInfo.transform.gameObject);
                            //selectedTarget = ;
                        }
                        //지면클릭
                        else{
                            hitPosition = new Vector3(hitInfo.point.x, 0f, hitInfo.point.z);
                            int layer = hitInfo.transform.gameObject.layer;

                            // UI일 시 종료
                            if (layer == UI_LAYER)
                                yield return null;

                            // 회전 및 목적지 설정
                            MoveManager.LookTarget(hitPosition);
                            MoveManager.TargetVector = new Vector3(hitInfo.point.x, 0f, hitInfo.point.z);
                        }
                    }
                }
            }
            yield return null;
        }
    }

    //경계모드 버튼 클릭 시 호출되는 메소드
    public void VigilanceButton()
    {
        //경계모드 일시 경계모드 중지
        if(Vigilance){
            VigilacneStop();
        }
        //경계모드가 아닐 시 경계모드 활성
        else{
            VigilanceActivate();
        }
    }

    
    // 경계모드 시작
    public void VigilanceActivate()
    {
        if (DEBUG_MODE)
            Debug.Log("Vigilance Activated");

        Vigilance = true;
        //정지
        MoveManager.Stop();

        //탐지범위를 사정거리로 변경
        GetComponentInChildren<DetectTrigger>().ChangeDetectRange(stats.CurrentStats[ATTACK_RANGE_INDEX]._value);
    }

    //경계모드 종료
    public void VigilacneStop()
    {
        if (DEBUG_MODE)
            Debug.Log("Vigilance Stopped");

        Vigilance = false;

        // MoveManager의 정지 비활성 메소드 호출
        MoveManager.DisableStop();

        // 기존의 원래 탐지범위 복구
        GetComponentInChildren<DetectTrigger>().ChangeDetectRange(stats.CurrentStats[DETECT_RANGE_INDEX]._value);

    }

}
