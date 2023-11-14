using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ClickerGame : MonoBehaviour
{
    public TMP_Text coinText;
    public int coins = 0;

    public Shop loja;

    private void Start()
    {
        // Load saved coins when the game starts
        LoadGame();
        UpdateCoinsText();
    }

    public void Click()
    {
        if (loja.upgradeLevel == 1)
        {
            coins++;
            UpdateCoinsText();
        }     
        else if (loja.upgradeLevel == 2)
        {
            coins = coins + 2;
            UpdateCoinsText();
        }
        else if (loja.upgradeLevel == 3)
        {
            coins = coins + 3;
            UpdateCoinsText();
        }
    }

    public void UpdateCoinsText()
    {
        // Update the TextMesh text
        coinText.text = "Coins: " + coins.ToString();
    }

    public void ResetGame()
    {
        // Reset coins to 0
        coins = 0;
        UpdateCoinsText();

        // Save the game after resetting
        SaveGame();
    }

    public void SaveGame()
    {
        // Save the current number of coins
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        // Load the saved number of coins
        coins = PlayerPrefs.GetInt("Coins", 0);
    }
}
