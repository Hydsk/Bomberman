using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMesh;
    GameObject player;
    public float dis;
    float disSave;

    Vector3 playerT;
    Vector3 enemyT; 

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.Find("/Player");
        
        disSave = dis;
    }

    // Update is called once per frame
    void Update()
    {
        playerT = player.transform.position;
        enemyT = transform.position;

        Debug.Log(Mathf.Abs(Mathf.Abs(playerT.x + playerT.z) - Mathf.Abs(enemyT.x + enemyT.z)));

        if(Mathf.Abs(Mathf.Abs(playerT.x + playerT.z) - Mathf.Abs(enemyT.x + enemyT.z)) <= dis)
        {
            navMesh.isStopped = false;
            navMesh.SetDestination(playerT);
        }
        else
        {
            navMesh.isStopped = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            dis = -999;
            navMesh.isStopped = true;
            Debug.Log("Colidiu");
            Destroy(player);
            StartCoroutine(stopFollow());
        }
    }
    IEnumerator stopFollow()
    {
        yield return new WaitForSeconds(1.0f);
        dis = disSave;
    }
}
