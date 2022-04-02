using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject text;
    public GameObject actualpanel;

    public GameObject glass;

    double transparency = 0;
    double transparency1 = 1;


    // Update is called once per frame
    void FixedUpdate()
    {
        text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color = new Color((float) text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.r, (float)text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.g, (float)text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.b, (float)transparency);
        glass.gameObject.GetComponent<Image>().GetComponent<Image>().color = new Color((float)glass.gameObject.GetComponent<Image>().color.r, (float)glass.gameObject.GetComponent<Image>().color.g, glass.gameObject.GetComponent<Image>().color.b, (float)transparency);
        Debug.Log(transparency);
        if(transparency <= 1) {
            transparency += 0.1*Time.deltaTime;
        } else {
            panel.gameObject.GetComponent<Image>().GetComponent<Image>().color = new Color((float)panel.gameObject.GetComponent<Image>().color.r, (float)panel.gameObject.GetComponent<Image>().color.g, panel.gameObject.GetComponent<Image>().color.b, (float)transparency1);
            glass.gameObject.GetComponent<Image>().GetComponent<Image>().color = new Color((float)glass.gameObject.GetComponent<Image>().color.r, (float)glass.gameObject.GetComponent<Image>().color.g, glass.gameObject.GetComponent<Image>().color.b, (float)transparency1);
            text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color = new Color((float) text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.r, (float)text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.g, (float)text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.b, (float)transparency1);
            Debug.Log(transparency1);
            if(transparency1 >= 0) {
                transparency1 -= 0.1*Time.deltaTime;
            } else {
                actualpanel.SetActive(false);
            }
        }
        
    }
}
