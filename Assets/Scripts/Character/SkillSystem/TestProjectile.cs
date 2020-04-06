using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestProjectile : MonoBehaviour {

    public float projectileMoveSpeed = 0.01f;
    public float projectileTurnSpeed = 360f;
    public float _attackDamage = 1f;
    GameObject TARGET;

    public bool isMoveState = false;

    CharacterController characterController;
	// Use this for initialization
	void Awake () {
        characterController = GetComponent<CharacterController>();

	}

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        Debug.Log("hit\t"+other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            Enemy_PointBar_Display epd = (Enemy_PointBar_Display)
                            other.gameObject.GetComponent("Enemy_PointBar_Display");

            Destroy(this.gameObject);
        }
            
    }

    public void SetDestinationObject(GameObject go)
    {
        TARGET = go;
        isMoveState = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isMoveState)
        {
            Vector3 moveDirection = TARGET.transform.position - transform.position;
            Vector3 directionXZ = new Vector3(moveDirection.x, 0, moveDirection.z);

            Vector3 targetPosition = transform.position + directionXZ;

            Vector3 framePosition = Vector3.MoveTowards(transform.position, targetPosition, projectileMoveSpeed * Time.deltaTime);

            Vector3 frameDirection = framePosition - transform.position;

            characterController.Move(frameDirection + Physics.gravity);

            //if (framePosition == targetPosition)
              //  isMoveState = false;
        }
	}

}
