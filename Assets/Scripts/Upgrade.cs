using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private GameManager gm;
    private Duck d;
    private Cannon c;

    public Sprite helmet1;
    public Sprite helmet2;
    public Sprite helmet3;

    public Sprite cannon1;
    public Sprite cannon2;

    public Button helmet1Button;
    public Button helmet2Button;
    public Button helmet3Button;

    public Button cannon1Button;
    public Button cannon2Button;

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
        //TODO: make buttons not interactable if not enough money
    }

    public void UpgradeHelmet(int level)
    {
        int cost = 0;
        switch (level)
        {
            case 1:
                cost = 100;
                break;
            case 2:
                cost = 300;
                break;
            case 3:
                cost = 800;
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
            switch (level)
            {
                case 1:
                    sr.sprite = helmet1;
                    helmet1Button.interactable = false;
                    break;
                case 2:
                    sr.sprite = helmet2;
                    helmet1Button.interactable = false;
                    helmet2Button.interactable = false;
                    break;
                case 3:
                    sr.sprite = helmet3;
                    helmet1Button.interactable = false;
                    helmet2Button.interactable = false;
                    helmet3Button.interactable = false;
                    break;
                default:
                    sr.sprite = null;
                    break;
            }
        }
    }

    public void UpgradeCannon(int level)
    {
        int cost = 0;
        int force = 0;
        switch (level)
        {
            case 1:
                cost = 100;
                force = 3750;
                break;
            case 2:
                cost = 250;
                force = 4750;
                break;
            default:
                cost = 0;
                force = 2500;
                break;
        }

        if (gm.money >= cost)
        {
            gm.reduceMoney(cost);
            d.launchSpeed = force;
            SpriteRenderer sr = d.transform.parent.GetComponent<SpriteRenderer>();
            switch (level)
            {
                case 1:
                    sr.sprite = cannon1;
                    cannon1Button.interactable = false;
                    break;
                case 2:
                    sr.sprite = cannon2;
                    cannon1Button.interactable = false;
                    cannon2Button.interactable = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void UpgradeJetpack()
    {
        if (gm.money >= 1000)
        {
            gm.reduceMoney(1000);
            d.jetpackUnlocked = true;
        }
    }
}
