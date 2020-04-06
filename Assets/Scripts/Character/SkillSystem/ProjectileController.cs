using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float damage;
    public float projectileSpeed;
    public float projectileRotationSpeed;
    public string EnemyTag = "Enemy";

    GameObject target;

    public float ProjectileSpeed
    {
        get
        {
            return projectileSpeed;
        }

        set
        {
            this.projectileSpeed = value;
        }
    }

    public float ProjectileRotationSpeed
    {
        get
        {
            return this.projectileRotationSpeed;
        }
        set
        {
            this.projectileRotationSpeed = value;
        }
    }

    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            this.target = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}

    void Initialize()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit\t" + other.gameObject.name);

        //충돌한 오브젝트가 적 일시 데미지를 주는 메소드 실행
        if (other.gameObject.tag == "Enemy"){
            DealingDamage(other.gameObject);
        }
    }

    //데미지 setter
    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    //목적지설정
    public void SetDestination(GameObject t)
    {
        target = t;
    }

    //투사체 이동 메소드
    public void Moving(Vector3 targetPos)
    {
        //타겟과의 거리 정규화
        Vector3 vector = (targetPos - transform.position).normalized;

        //타겟을 향해 회전할 방향
        Quaternion LookQuaternion = Quaternion.LookRotation(vector);

        //회전
        transform.rotation = Quaternion.Slerp(transform.rotation, LookQuaternion, projectileRotationSpeed * Time.deltaTime);

        //타겟에 도달시 까지 이동
        if(Vector3.Distance(target.transform.position, transform.position) >= 0 )
             transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);

    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        //타겟이 null이 아닐떄, 타겟과의 거리가 0보다 클때 계속 이동시킴
		if(target!= null && Vector3.Distance(this.transform.position, target.transform.position)>0){
            ProjectileMoving(target.transform.position);
        }
	}

    //투사체를 움직이는 메소드. 인터페이스
    public void ProjectileMoving(Vector3 destination)
    {
        Moving(destination);
    }

    //투사체가 타겟에게 데미지를 주는 처리를 하는 메소드. 인터페이스
    public void DealingDamage(GameObject target)
    {
        StatManager enemy = target.gameObject.GetComponent<StatManager>();

        //타겟에게 데미지를 가함
        enemy.TakeDamage(damage);

        // 투사체 소멸
        Destroy(this.gameObject);
    }
}
