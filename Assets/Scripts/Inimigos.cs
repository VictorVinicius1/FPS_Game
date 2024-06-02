using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigos : MonoBehaviour

{
    public World World; 
    public GameObject player;
    public Transform target;
    NavMeshAgent agent;

    public GameObject hp;
    public float HPENEMY = 1;

    void Start()
    {
        World = GameObject.FindWithTag("World").GetComponent<World>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        hp.transform.localScale = new Vector3(HPENEMY, 0.1f, 0.1f);
        if (HPENEMY <= 0)
        {
            
            Destroy(this.gameObject);
            World.enemy_actually_in_wave--;
            //World.PointsCount++;
            //World.numeroatualenemy--;
        }

    }
}
