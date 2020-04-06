using UnityEngine;
using System.Collections;

class GameObjectPair
{
	private string _name;
	private GameObject _gameObject;

	public string name
	{
		get { return _name; }
		set { _name = value; }
	}
	public GameObject gameObject
	{
		get { return _gameObject; }
		set { _gameObject = value; }
	}

	//constructor
	public GameObjectPair(string n, GameObject go)
	{
		this._name = n;
		this._gameObject = go;

	}
}