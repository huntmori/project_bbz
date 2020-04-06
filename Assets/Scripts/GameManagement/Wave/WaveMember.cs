using UnityEngine;
using System.Collections;

public class WaveMember
{
    private string _name;   //웨이브 맴버 이름
    private int _amount;    //해당 맴버 생성 수량
    private int _counter;   // 내부 count용 카운터
    private Vector3 _location;  // 젠 위치

//Getter Setter
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int amount
    {
        get { return _amount; }
        set { _amount = value; }
    }
    public Vector3 location
    {
        get { return _location; }
        set { _location = value; }
    }
    public int counter
    {
        get { return _counter; }
        set { _counter = value; }
    }

    public WaveMember(string n, int a, Vector3 lo)
    {
        this._name = n;
        this._amount = a;
        this._location = lo;
        this._counter = 0;
    }

    // 생성 될 맴버가 남았는지 체크
    public bool IsNext()
    {
        return _counter < _amount;
    }
    // 맴버 카운터 증가
    public bool IncreaseCounter()
    {
        if (_counter < _amount)
        {
            _counter++;
            return true;
        }
        else
            return false;
    }

    public void TEST()
    {
        _name = "CubeEnemy";
        _amount = 10;
        _location = new Vector3(0, 0, 0);
    }
}