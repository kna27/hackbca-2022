using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public GameObject shop;
    public Button shopBtn;
    private bool shopWasShown;
    void Update()
    {
        if (GameObject.Find("Duck").GetComponent<Duck>().launched)
        {
            shopWasShown = shop.activeInHierarchy;
            shop.SetActive(false);
            shopBtn.interactable = false;
        }
        else
        {
            if (shopWasShown)
            {
                shop.SetActive(true);
                shopWasShown = false;
            }
            shopBtn.interactable = true;
        }
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
