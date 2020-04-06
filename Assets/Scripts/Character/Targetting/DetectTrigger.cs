using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{
    TargettingManager targettingManager;
    LayerMask TargetLayer;

    string EnemyTag;
    bool DEBUG_MOD = false;

    // Use this for initialization
    void Start()
    {
        //?봔筌뤴몿而쇽㎗???GameObject'??'???癒?퐣 TargettingManager 筌〓챷??
        targettingManager = GetComponentInParent<TargettingManager>();
        TargetLayer = new LayerMask();

        if (this.transform.parent.tag == "Player")
        {
            TargetLayer = LayerMask.NameToLayer("Minion");
            EnemyTag = "Enemy";
        }
        else if (this.transform.parent.tag == "Enemy")
        {
            TargetLayer = LayerMask.NameToLayer("Hero");
            EnemyTag = "Ally";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Sphere Collider??Radius??獄쏆룇? 揶쏅??앮에?癰궰野?
    public void ChangeDetectRange(float value)
    {
        SphereCollider temp = GetComponent<SphereCollider>();
        temp.radius = value;
    }

    // ?겸뫖猷????紐꾪뀱
    private void OnTriggerEnter(Collider other)
    {
        // ?怨밴묶域밸챷? ??덉뵬 ????
        if (other.gameObject.tag == EnemyTag)
        {
            if (DEBUG_MOD)
                Debug.Log("Enemy Entered\t" + other.gameObject.name + "\n" + other.name);

            //??野?筌롫뗀??????겸뫖猷?????곕떽?
            targettingManager.AddTarget(other.gameObject);
        }//(other.gameObject.tag == EnemyTag)
    }

    // Collider?癒?퐣 甕곗щ선 ????
    private void OnTriggerExit(Collider other)
    {
        // 甕곗щ선????삵닏??븍뱜揶쎛 ????野껋럩??
        if (other.gameObject.tag == EnemyTag)
        {
            if (DEBUG_MOD)
			{
				
			}
			targettingManager.RemoveTargetFromList(other.gameObject);
		}
	}
}