using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowShop()
    {
        shop.SetActive(!shop.activeInHierarchy);
    }
    // Reduces money by int i (if it won't result in a negative number)
    public void reduceMoney(int i){
        if(i <= money){
            money -= i;
        } 
    }

    // Increases money by int i (if it is positive)
    void increaseMoney(int i){
        if(i > 0){
            money += i;
        }
    }


}
