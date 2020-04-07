using UnityEngine;
using System.Collections;

/// <summary>
/// 타게팅 정보 클래스.
/// </summary>
public class TargetInfo
{
	public Transform transform;
	public Color defaultColor;
	public Color selectColor;

	public TargetInfo(Transform tr, Color def, Color select)
	{
		transform = tr;
		defaultColor = def;
		selectColor = select;
	}
	public TargetInfo(GameObject go, string tag)
	{
		transform = go.transform;
		defaultColor = go.GetComponent<Renderer>().material.color;

		if(go.tag.Equals("Enemy"))
			selectColor = Color.red;
		else if(go.tag.Equals("Player"))
			selectColor = Color.green;
	}
    /// <summary>
    /// 생성자- go의 참조와 go의 태그를 위생성자로 재호출
    /// </summary>
    /// <param name="go"></param>
    public TargetInfo(GameObject go):this(go, go.tag)
    {    }

	public TargetInfo()
	{
		transform = null;
	}

	//temp.transform.GetComponent<Renderer>().material.color = temp.Value;
	public void SetSelectedColor()
	{
		if(this.transform != null)
			transform.GetComponent<Renderer> ().material.color = this.selectColor;
	}
	public void SetDefaultColor()
	{
		if(this.transform != null)
			transform.GetComponent<Renderer> ().material.color = this.defaultColor;
	}

}
