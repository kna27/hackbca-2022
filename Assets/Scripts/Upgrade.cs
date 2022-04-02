using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private GameManager gm;
    private Duck d;
    private Cannon c;

    public Sprite helmet1;
    public Sprite helmet2;
    public Sprite helmet3;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        d = GameObject.Find("Duck").GetComponent<Duck>();
        c = GameObject.Find("CannonBase").GetComponent<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeHelmet(int level)
    {
        int cost = 0;
        switch (level)
        {
            case 1:
                cost = 500;
                break;
            case 2:
                cost = 1000;
                break;
            case 3:
                cost = 2000;
                break;
            default:
                cost = 0;
                break;
        }

        if (gm.money >= cost)
        {
            gm.reduceMoney(cost);
            d.helmetLevel = level;
            SpriteRenderer sr = d.helmet.GetComponent<SpriteRenderer>();
            sr.sprite = level switch
            {
                0 => null,
                1 => helmet1,
                2 => helmet2,
                3 => helmet3,
                _ => null,
            };
        }
    }

    public void UpgradeCannon(int level)
    {

    }

    public void UpgradeJetpack()
    {
        if (gm.money >= 10000)
        {
            gm.reduceMoney(10000);
            d.jetpackUnlocked = true;
        }
    }
}
