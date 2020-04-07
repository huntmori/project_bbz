using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 웨이브 전체를 관리하는 클래스 -> WaveManager로 바꿀 예정
/// </summary>
public class WaveController : MonoBehaviour
{
    // 웨이브의 리스트
    public List<Wave> waveList;

    // 플레이어 리스트
    public List<GameObject> playerList;

    // 현재 지나온 웨이브에 대한 카운터
    public int waveCount;

    public float generateCoolDown;  //생성 쿨다운
    public float timeCounter;   // 시간 카운터

    public PrefabList prefabList;
    public GameObject prefab;

    public GameController gameController;

    public bool DEBUG_MOD=false;

    // Use this for initialization
    public void Initialize()
    {
        prefabList = new PrefabList();
        waveList = new List<Wave>();

        //플레이어들의 Targetting을 관리하기 위해 참조
        GameObject[] pl = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < pl.Length; i++)
            playerList.Add(pl[i]);

        waveCount = 0;
        generateCoolDown = 1f;
        timeCounter = 0f;

        // 게임 컨트롤러 참조
        gameController = GetComponent<GameController>();
    }
    void Awake()
    {
        Initialize();
        TEST();
    }

    // 웨이브 생성 / 오브젝트 생성 조건 메소드
    public bool GenerateCondition()
    {
        //전투 페이즈 AND 현재 웨이브에 남은 waveMember(몬스터)가 존재하는지를 리턴
        return gameController.nowPhase.Equals(gameController.BATTLE) && waveList[waveCount].IsNext();
    }
    public bool CreateCondition()
    {
        // 생성 할 웨이브 맴버가 남아있고, 쿨타운이 되면 생성
        return (timeCounter >= generateCoolDown) && (waveList[waveCount].IsNext());
    }


    // Update is called once per frame
    void Update()
    {
        if(DEBUG_MOD){
            Debug.Log(prefabList.Debug());
            Debug.Log(prefabList.IsExist("CubeEnemy"));
        }
        
        timeCounter += Time.deltaTime;

        //BATTLE 상태일 시 만 웨이브 생성
        if ( GenerateCondition()){
            if ( CreateCondition())
                GenerateWave(waveCount);
        }
        else{
            timeCounter = 0f;
        }
    }

    public void TEST()
    {
        Wave test = new Wave();

        AddWave(test);
    }

    //다음 웨이브가 있는지 체크
    public bool IsNext()
    {
        return waveCount < (waveList.Count - 1);
    }
    //웨이브 카운트 증가
    public bool IncreaseCounter()
    {
        // 웨이브가 남아 있을 시 카운트를 증가시키고 true리턴
        if (waveCount < waveList.Count)
        {
            waveCount++;
            return true;
        }
        // 더이상 다음 웨이브가 없을 시 false리턴
        else
            return false;

    }

    //웨이브 추가 메소드
    public void AddWave(Wave wave)
    {
        Wave temp = wave;
        //temp.TEST();
        waveList.Add(temp);
    }

    //웨이브가 종료되었는지 리턴
    public bool IsWaveEnd()
    {
        return !(waveList[waveCount].IsNext());
    }

    // 파라메터로 받은 라운드의 웨이브 생성
    public void GenerateWave(int waveNumber)
    {
        Wave wave = waveList[waveNumber];
        Debug.Log(wave.Debug());

        if (wave != null && wave.IsNext()){
            // 프리팹 생성을 위한 값 할당
            WaveMember member = wave.GetWaveMemberByCounter();

            if (member.IsNext()){
                // 맴버 이름으로 prefabList에서 게임오브젝트(프리팹)을 받아온다
                GameObject gameObject = prefabList.GetGameObjectByName (member.name);
                Quaternion angle = new Quaternion(0, 0, 0, 0);

                //프리팹 생성 & 이름 설정
                prefab = Instantiate(gameObject, member.location, angle) as GameObject;
                prefab.name = prefab.name + (member.counter + 1);

                // 맴버의 카운터 증가.
                member.IncreaseCounter();

                //타겟팅에 추가하기 위한 타겟정보
                GameObject enemy = prefab;

                // 모든 플레이어의 Targetting 컴포넌트에 생성된 오브젝트 추가 및 정렬
                for(int i=0; i<playerList.Count; i++){
                    TargettingManager tg = playerList[i].GetComponent<TargettingManager>();
                    tg.AddTarget(enemy);
                    tg.SortTargetByDistance();

                    //if (i == 0)
                        //tg.TargetEnemy();
                }

                // 맴버 생성이 모두 완료되면, 웨이브 카운트 증가
                if (!member.IsNext())
                    wave.IncreaseCount();

                prefab = null;
                // 생성 타이머를 0f로 초기화
                timeCounter = 0f;
            }
        }
    }
}