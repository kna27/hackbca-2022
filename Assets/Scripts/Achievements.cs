using UnityEngine;
using UnityEngine.UI;
public class Achievements : MonoBehaviour
{
    public Color lockedColor;
    public Color unlockedColor;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    int maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = PlayerPrefs.GetInt("maxHeight");
       // Image img1 = GameObject.Find("Achievements/Canvas/Panel/Panel").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        a1.GetComponent<Image>().color = maxHeight >= 50 ? unlockedColor : lockedColor;
        a2.GetComponent<Image>().color = maxHeight >= 200 ? unlockedColor : lockedColor;
        a3.GetComponent<Image>().color = maxHeight >= 500 ? unlockedColor : lockedColor;
        a4.GetComponent<Image>().color = maxHeight >= 650 ? unlockedColor : lockedColor;

    }

}
