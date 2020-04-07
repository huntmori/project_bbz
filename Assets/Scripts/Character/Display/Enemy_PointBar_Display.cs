using UnityEngine;
using System.Collections;
using System;

public class Enemy_PointBar_Display : MonoBehaviour
{
	enum barNames : int{
		facePicture,    health, mana,   exp
	};
	enum rectParameter{
		left,   top,    width,  height, max,    curr
	};
	enum barValues{
		max, current
	};
	
	// 각 Enum Name에 대한 값을 상수로 지정
	const int LEFT = (int)rectParameter.left;
	const int TOP = (int)rectParameter.top;
	const int WIDTH = (int)rectParameter.width;
	const int HEIGHT = (int)rectParameter.height;
	
	const int FACEPIC = (int)barNames.facePicture;
	const int HEALTHBAR = (int)barNames.health;
	const int MANABAR = (int)barNames.mana;
	const int EXPBAR = (int)barNames.exp;
	
	const int MAX = (int)barValues.max;
	const int CURRENT = (int)barValues.current;

    public CharacterStat CurrentHP, CurrentMP, MaxHP, MaxMP;
    CharacterStat[] HP;
    CharacterStat[] MP;

	public int[] exp;
	
	public float healthBarLength;
	public float manaBarLength;
	public float expBarLength;
	
    // 각 GUI 위치값
	public float[][] posValues;

    // 정보 표시 활성화 / 비활성화
	public bool isVisible;
	
    public void Initialize()
    {
        //각 Enum의 길이
        int numberOfBar = Enum.GetNames(typeof(barNames)).Length;
        int numberOfRectParameter = Enum.GetNames(typeof(rectParameter)).Length;

        //Bar(hp바, Mp바, exp바)들의 인덱스에 대해 생성
        posValues = new float[numberOfBar][];

        //사각형 GUI의 위치값들을 위한 공간 할당
        for (int i = 0; i < posValues.Length; i++)
            posValues[i] = new float[numberOfRectParameter];

        //체력/마나/경험치등의 현재/최대 배열 생성을 위한 Enum길이
        int barArrayLength = System.Enum.GetNames(typeof(barValues)).Length;

        exp = new int[barArrayLength];

        // 체력/마나의 현재/최대치를 StatManager로부터 참조
        StatManager tempStat = GetComponent<StatManager>();
        CurrentHP = tempStat.CurrentStats[(int)IndexEnumList.StatNames.currentHealth];
        CurrentMP = tempStat.CurrentStats[(int)IndexEnumList.StatNames.currentSkillResource];
        MaxHP = tempStat.CurrentStats[(int)IndexEnumList.StatNames.maxHealth];
        MaxMP = tempStat.CurrentStats[(int)IndexEnumList.StatNames.maxSkillResource];

        //참조
        HP = new CharacterStat[2];
        HP[MAX] = MaxHP;
        HP[CURRENT] = CurrentHP;

        MP = new CharacterStat[2];
        MP[MAX] = MaxMP;
        MP[CURRENT] = CurrentMP;

        exp[MAX] = 100;
        exp[CURRENT] = 1;

        int barLength = 35;
        int barHeight = 10;

        //각 요소의 좌표값/크기에 대한 값 할당
        posValues[FACEPIC][LEFT] = Screen.width / 2 - 25;
        posValues[FACEPIC][TOP] = 15;
        posValues[FACEPIC][WIDTH] = 25;
        posValues[FACEPIC][HEIGHT] = 25;

        posValues[HEALTHBAR][LEFT] = Screen.width / 2;
        posValues[HEALTHBAR][TOP] = 20;
        posValues[HEALTHBAR][WIDTH] = barLength;
        posValues[HEALTHBAR][HEIGHT] = barHeight;

        posValues[MANABAR][LEFT] = posValues[HEALTHBAR][LEFT];
        posValues[MANABAR][TOP] = posValues[HEALTHBAR][TOP] + 10;
        posValues[MANABAR][WIDTH] = barLength;
        posValues[MANABAR][HEIGHT] = barHeight;

        posValues[EXPBAR][LEFT] = 0;
        posValues[EXPBAR][TOP] = 0;
        posValues[EXPBAR][WIDTH] = 0;
        posValues[EXPBAR][HEIGHT] = 0;

        isVisible = false;
    }
	// Use this for initialization
	void Start ()
	{
        Initialize();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    //경험치 증감메소드
	public void UpdateCurrentExp(int value)
	{	
		exp[CURRENT] += value;	
		
		if (exp [CURRENT] < 0)
			exp [CURRENT] = 0;
		
		if (exp [CURRENT] > exp [MAX])
			exp [CURRENT] = exp [MAX];
		
		if (exp [MAX] < 1)
			exp [MAX] = 1;
	}
	
	void OnGUI()
	{
		if(isVisible)
			for(int i=0; i<posValues.Length; i++){
				string boxText="";
				float rate=0;	// rate is point Bar Rate.
				
                // 각 요소 내부 값 설정
				switch(i){
				    case FACEPIC:
					    boxText = "초상화";
					    rate = 1;
					    break;
					
				    case HEALTHBAR:
					    boxText = HP[CURRENT]._value + " / " + HP[MAX]._value;
					    rate = (float)HP[CURRENT]._value/(float)HP[MAX]._value;
					    break;
					
				    case MANABAR:
					    boxText = MP[CURRENT]._value + " / " + MP[MAX]._value;
					    rate =  (float)MP[CURRENT]._value / (float)MP[MAX]._value;
					    break;
				    case EXPBAR:
					    boxText = exp[CURRENT] + " / " + exp[MAX];
					    rate = 1;
					    break;
				}
				
                //실제 박스 생성
				GUI.Box(new Rect(
					posValues[i][LEFT],
					posValues[i][TOP],
					posValues[i][WIDTH] * rate,
					posValues[i][HEIGHT]
					),	boxText    );
			}
	}
}
