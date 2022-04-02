using UnityEngine;

public class Spawner : MonoBehaviour
{
    Duck d;
    public GameObject[] altLvl1Enemies;
    public GameObject[] altLvl2Enemies;
    public GameObject[] altLvl3Enemies;
    GameObject[] powerups;
    System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        d = GameObject.Find("Duck").GetComponent<Duck>();
        for (int i = 5; i < d.altLvl2; i += 20)
        {
            Vector3 pos = new Vector3(rand.Next(-15, -10), i, 0);
            Instantiate(altLvl1Enemies[rand.Next(0, altLvl1Enemies.Length)], pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
