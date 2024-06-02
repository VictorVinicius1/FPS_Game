using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject Enemy;
    public float TimeSpawnEnemy;
    public int wave;
    public int wavemax = 4;
    public List<int> enemy_total_per_Wave = new List<int> { 2, 5, 7, 10 };
    public int enemy_actually_in_wave;
    public int enemy_add_in_wave = 0;
    public bool spawn;
    public int cont;


    public GameObject Munition;
    public float TimeSpawnMunition;
    int munitionmax = 5;
    int munitionatual = 0;

    public GameObject limite_spawn_min_x;
    public GameObject limite_spawn_max_x;
    public GameObject limite_spawn_min_z;
    public GameObject limite_spawn_max_z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnwaves();
        TimeSpawnEnemy -= Time.deltaTime;
        TimeSpawnMunition -= Time.deltaTime;
        if (TimeSpawnMunition < 0 && munitionatual <= munitionmax)
        {
        }
    }
    private void spawnwaves()
    {
       
    }
}


