using UnityEngine;
using System.Collections;

public class Player_PointBar_Display : MonoBehaviour
{
    // 각 Enum Name에 대한 값을 상수로 지정
    public const int LEFT = (int)IndexEnumList.RectParameter.left;
	public const int TOP = (int)IndexEnumList.RectParameter.top;
	public const int WIDTH = (int)IndexEnumList.RectParameter.width;
	public const int HEIGHT = (int)IndexEnumList.RectParameter.height;

	public const int FACEPIC = (int)IndexEnumList.PointBarNames.facePicture;
	public const int HEALTHBAR = (int)IndexEnumList.PointBarNames.health;
	public const int MANABAR = (int)IndexEnumList.PointBarNames.mana;
	public const int EXPBAR = (int)IndexEnumList.PointBarNames.exp;

	public const int MAX = (int)IndexEnumList.BarValues.max;
	public const int CURRENT = (int)IndexEnumList.BarValues.current;

    public CharacterStat CurrentHealth;
    public CharacterStat CurrentMana;
    public CharacterStat MaxHealth;
    public CharacterStat MaxMana;


    public int[] health;
	public int[] mana;
	public int[] exp;

	public float healthBarLength;
	public float manaBarLength;
	public float expBarLength;

	public float[][] posValues;

	// Use this for initialization
	void Start ()
	{
		int numberOfBar = System.Enum.GetNames (typeof(IndexEnumList.PointBarNames)).Length;
		int numberOfRectParameter = System.Enum.GetNames (typeof(IndexEnumList.RectParameter)).Length;

		posValues = new float[numberOfBar][];
		for (int i=0; i<posValues.Length; i++)
			posValues [i] = new float[numberOfRectParameter];

		int barArrayLength = System.Enum.GetNames (typeof(IndexEnumList.BarValues)).Length;

		health = new int[barArrayLength];
		mana = new int[barArrayLength];
		exp = new int[barArrayLength];

        StatManager stat = GetComponent<StatManager>();

        CurrentHealth = stat.CurrentStats[(int)IndexEnumList.StatNames.currentHealth];
        CurrentMana = stat.CurrentStats[(int)IndexEnumList.StatNames.currentSkillResource];
        MaxHealth = stat.CurrentStats[(int)IndexEnumList.StatNames.maxHealth];
        MaxMana = stat.CurrentStats[(int)IndexEnumList.StatNames.maxSkillResource];


		health [MAX] = 1000;
		health [CURRENT] = 1000;

		mana [MAX] = 100;
		mana [CURRENT] = 100;

		exp[MAX] = 100;
		exp[CURRENT]=1;

		posValues [FACEPIC][LEFT] = 5;
		posValues [FACEPIC][TOP] = 10;
		posValues [FACEPIC][WIDTH] = 50;
		posValues [FACEPIC][HEIGHT] = 50;

		posValues [HEALTHBAR][LEFT] = 60;
		posValues [HEALTHBAR][TOP] = 10;
		posValues [HEALTHBAR][WIDTH] = Screen.width / 4 ;
		posValues [HEALTHBAR][HEIGHT] = 20;

		posValues [MANABAR][LEFT] = 60;
		posValues [MANABAR][TOP] = 40;
		posValues [MANABAR][WIDTH] =  Screen.width / 4  ;
		posValues [MANABAR][HEIGHT] = 20;

		posValues [EXPBAR][LEFT] = 60;
		posValues [EXPBAR][TOP] = 65;
		posValues [EXPBAR][WIDTH] = Screen.width/4;
		posValues [EXPBAR][HEIGHT] = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

    // value만큼 경험치를 갱신한다.
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
		for(int i=0; i<posValues.Length; i++)
		{
			string boxText="";
			float rate=0;	// rate is point Bar Rate.

			switch(i)
			{
				case FACEPIC:
					boxText = "초상화";
					rate = 1;
					break;

			    case HEALTHBAR:
					boxText = CurrentHealth._value + " / " + MaxHealth._value;
					rate = CurrentHealth._value / MaxHealth._value;
					break;

				case MANABAR:
					boxText = CurrentMana._value + " / " + MaxMana._value;
					rate = CurrentMana._value / MaxMana._value;
					break;
				case EXPBAR:
					boxText = exp[CURRENT] + " / " + exp[MAX];
					rate = 1;
					break;
			}

			GUI.Box(new Rect(
							 posValues[i][LEFT],
			                 posValues[i][TOP],
			                 posValues[i][WIDTH] * rate,
			                 posValues[i][HEIGHT]
			                ),	boxText    );
		}
	}
}
