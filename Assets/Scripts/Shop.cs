using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Shop : MonoBehaviour
{
    public TMP_Text upgradeLevelText;
    public TMP_Text upgradeCostText;
    public GameObject shopCanvas;
    public GameObject coinCanvas;

    public static Shop Instance;

    public ClickerGame click;
    
    public int upgradeLevel = 1;
    private int upgradeCost = 100;


    private void Start()
    {
        CloseShop();
        UpdateUpgradeUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Toggle the shop canvas
            OpenShop();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Close the shop canvas
            CloseShop();
        }
    }

    //public void SetCoins(int coins)
    //{
      //  this.coins = coins;
        //UpdateUpgradeUI();
    //}

    public void BuyUpgrade()
    {
        // Check if the player has enough coins to buy the upgrade
        if (click.coins >= upgradeCost && upgradeLevel < 3)
        {
            // Deduct the cost and increase the upgrade level
            click.coins -= upgradeCost;
            upgradeLevel++;
            UpdateUpgradeUI();

            // Increase the cost of the next upgrade 
            upgradeCost = upgradeCost * upgradeLevel;

            // Save the game state 
            SaveGame();
        }
        else
        {
            Debug.Log("Not enough coins to buy the upgrade or Level Max");
        }
    }

    public void UpdateUpgradeUI()
    {
        // Update the UI elements to reflect the current upgrade level and cost
        int newSize = 18; // Replace this with the desired font size
        if (upgradeLevel < 3)
        {
            upgradeLevelText.text = "Upgrade Level: " + upgradeLevel.ToString();
            upgradeLevelText.fontSize = newSize;
            click.UpdateCoinsText();
        }
        else
        {
            upgradeLevelText.text = "Upgrade Level: MAX";
            upgradeLevelText.fontSize = newSize;
            click.UpdateCoinsText();
        }

        upgradeCostText.text = "Upgrade Cost: " + upgradeCost.ToString();
        upgradeCostText.fontSize = newSize;
    }

    private void SaveGame()
    {
        // Em progresso
    }

    public void OpenShop()
    {
        shopCanvas.SetActive(true);
        coinCanvas.SetActive(false);
    }

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
        coinCanvas.SetActive(true);
    }
}
