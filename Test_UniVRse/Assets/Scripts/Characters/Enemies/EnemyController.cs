using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    const float CHANGE_TARGET_THRESHOLD = 0.5f;

    [SerializeField] BoxCollider moveArea;
    [SerializeField] float triggerDestroyDistance = 3f;

    Transform playerRef;
    AreaLimits moveLimits;
    Vector3 targetPosition = Vector3.zero;
    bool objectSpawned = false;

    private void Start()
    {
        GetAllComponents();

        if (!objectSpawned)
        {
            moveLimits = new AreaLimits(moveArea);
            targetPosition = GetRndTargetPosition();
        }
    }

    protected override void GetAllComponents()
    {
        base.GetAllComponents();

        playerRef = FindObjectOfType<PlayerController>().transform;
    }

    public void SpawnInit(AreaLimits _moveLimits)
    {
        objectSpawned = true;
        moveLimits = _moveLimits;
        targetPosition = GetRndTargetPosition();
    }


    // Update is called once per frame
    void Update()
    {
        MoveBetweenTargetsBehaviour();
        DestroyNearPlayerBehaviour();
    }


    void MoveBetweenTargetsBehaviour()
    {
        if (Vector3.Distance(transform.position, targetPosition) > CHANGE_TARGET_THRESHOLD)
        {
            MoveToTarget();
        }
        else
        {
            targetPosition = GetRndTargetPosition();
        }
    }

    void MoveToTarget()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        characterMovement.Move(moveDir);
        RotateToDirection(moveDir);
    }

    void RotateToDirection(Vector3 _lookDir)
    {
        Quaternion targetRotation = Quaternion.LookRotation(_lookDir, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 2f);
    }

    Vector3 GetRndTargetPosition()
    {
        Vector3 rndTargetPosition = new Vector3(
            Random.Range(moveLimits.minX, moveLimits.maxX),
            transform.position.y,
            Random.Range(moveLimits.minZ, moveLimits.maxZ)
        );

        return rndTargetPosition;
    }

    void DestroyNearPlayerBehaviour()
    {
        if (Vector3.Distance(transform.position, playerRef.position) < triggerDestroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        EnemyVisibilityZone enemyVisibilityZone = GetComponent<EnemyVisibilityZone>();
        if (enemyVisibilityZone != null)
            enemyVisibilityZone.RemoveAllVisibilityZones();
    }

}
