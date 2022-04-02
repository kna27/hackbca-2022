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
        for (int i = 5; i < d.altLvl2; i += 10)
        {
            Vector3 pos = new Vector3(rand.Next(-15, -10), i, 0);
            Instantiate(altLvl1Enemies[rand.Next(0, altLvl1Enemies.Length)], pos, Quaternion.identity);
        }
        for (int i = d.altLvl2; i < d.altLvl3; i += 10)
        {
            Vector3 pos = new Vector3(rand.Next(-15, -10), i, 0);
            Instantiate(altLvl2Enemies[rand.Next(0, altLvl2Enemies.Length)], pos, Quaternion.identity);
        }
        for (int i = d.altLvl3; i < 700; i += 10)
        {
            Vector3 pos = new Vector3(rand.Next(-15, -10), i, 0);
            Instantiate(altLvl3Enemies[rand.Next(0, altLvl3Enemies.Length)], pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
