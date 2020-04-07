using UnityEngine;
using System.Collections;

/// <summary>
/// 이름 : PhaseManger로 바꿀 예정
/// </summary>
public class GameController : MonoBehaviour
{
    public Phase nowPhase;  // 현재 상태 참조

    // 각 Phase상태
    public Phase START;
    public Phase READY;
    public Phase BATTLE;
    public Phase END;

    // 이번 게임의 웨이브 메니저
	public WaveController waveController;

	public float timeCounter;
	public float totalTime;

	public GameObject[] players;

    public bool DEBUG_MODE = false;
    
    // Use this for initialization
    public void Initialize()
    {
        START = new Phase("Start");
        READY = new Phase("Ready");
        BATTLE = new Phase("Battle");
        END = new Phase("End");

        nowPhase = START;

        waveController = GetComponent<WaveController>();

        timeCounter = 0f;
        totalTime = 0f;

        players = GameObject.FindGameObjectsWithTag("Player");
        //Start ();
    }
    void Awake()
    {
        Initialize();
    }
	// Update is called once per frame
	void Update ()
    {
		totalTime += Time.deltaTime;
        //totalTime += Time.deltaTime;

        if(DEBUG_MODE)
            Debug.Log("PHASE NAME\t" + nowPhase.name + "\tTIME :\t" + totalTime);

        /// <summary>
        /// START페이즈나 READY페이즈 일 경우 타이머. 시간이 만료되면 다음 상태로 전이된다.
        /// </summary>
        if (nowPhase.Equals (START) || nowPhase.Equals(READY)) {
			timeCounter += Time.deltaTime;

			if (timeCounter >= nowPhase.timeLimit) {
				timeCounter = 0f;

				if (nowPhase.Equals (START)) {
					nowPhase = READY;
					Ready ();
				}
				else if (nowPhase.Equals (READY)) {
					nowPhase = BATTLE;
					Battle ();
				}
			}
		}
        /// <summary>
        /// 전투 페이즈 시 웨이브 생성이 끝났고, 타겟팅 배열이 비어있을 경우 Ready상태로 이동.
        /// </summary>
        else if (nowPhase.Equals(BATTLE)){
			timeCounter += Time.deltaTime;

			if (waveController.IsWaveEnd() && IsTargettingClear()) {
				timeCounter = 0f;
				nowPhase = READY;
				Ready ();
			}

		}
	}

    /// <summary>
    /// 타게팅 배열이 비어있는지 확인, 리턴한다.
    /// </summary>
    public bool IsTargettingClear()
	{
		for(int i=0; i<players.Length; i++){
			TargettingManager tg = players [i].GetComponent<TargettingManager> ();
			if (!tg.IsEmpty ())
				return false;
		}

		return true;
	}
	public void Start()
	{
		//do initialize
        if(DEBUG_MODE)
		    Debug.Log("START");
//      waveController.TEST();
    }

	public void Ready()
	{
		Debug.Log("READY");
	}
	public void Battle()
	{
		Debug.Log("BATTLE");
	}
	public void End()
	{
		Debug.Log("END");
	}
}
