using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   // 스크립트에서 내비게이션 시스템 기능을 사용하려면 AI 네임스페이스를 using 선언해야함

public class Moveable : MonoBehaviour
{
    // 길을 찾아서 이동할 에이전트
    NavMeshAgent agent;

    public bool isCrash = false;

    // 에이전트의 목적지
    [SerializeField]
    Transform target;

    private void Awake()
    {
        // 게임이 시작되면 게임 오브젝트에 부착된 NavMeshAgent 컴포넌트를 가져와서 저장
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!isCrash)
        {
            // 에이전트에게 목적지를 알려주는 함수
            agent.SetDestination(target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            isCrash = true;
        }

        Debug.Log("Target 충돌!");
    }
}
