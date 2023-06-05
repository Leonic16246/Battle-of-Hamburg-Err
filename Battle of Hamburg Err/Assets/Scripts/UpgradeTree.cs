using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTree : MonoBehaviour
{
    [SerializeField]
    string turretName;
    
    [Header("Upgrade Buttons")]
    public GameObject upgradeButton1;
    public GameObject upgradeButton2;
    public GameObject upgradeButton3;

    [Header("UI")]
    public TextMeshProUGUI maxedOutText;
    [SerializeField]
    UpgradesUI upgradeUI;

    int upgradeLvl = 0;
    int nextUpgradeCost;

    // Set button status based on upgrades already owned.
    private void Start()
    {
        if (PlayerPrefs.HasKey(turretName))
        {
            upgradeLvl = PlayerPrefs.GetInt(turretName);
        }

        if (upgradeLvl >= 1)
        {
            upgradeButton1.GetComponent<Button>().interactable = false;
            upgradeButton2.GetComponent<Button>().interactable = true;
            if (upgradeLvl >= 2)
            {
                upgradeButton2.GetComponent<Button>().interactable = false;
                upgradeButton3.GetComponent<Button>().interactable = true;
                if (upgradeLvl == 3)
                {
                    upgradeButton3.GetComponent<Button>().interactable = false;
                    maxedOutText.gameObject.SetActive(true);
                }
            }
        }

        nextUpgradeCost = upgradeLvl + 1;
    }

    // Set the turret level + update skill points #.
    public void Upgrade()
    {
        int skillPoints = upgradeUI.GetSkillPoints();

        if (skillPoints >= nextUpgradeCost)
        {
            upgradeLvl++;
            skillPoints -= nextUpgradeCost;
            nextUpgradeCost++;

            PlayerPrefs.SetInt(turretName, upgradeLvl);
            upgradeUI.SetSkillPoints(skillPoints);

            // Make the next upgrade available.
            if (upgradeLvl == 1)
            {
                upgradeButton1.GetComponent<Button>().interactable = false;
                upgradeButton2.GetComponent<Button>().interactable = true;
            }
            else if (upgradeLvl == 2)
            {
                upgradeButton2.GetComponent<Button>().interactable = false;
                upgradeButton3.GetComponent<Button>().interactable = true;
            }
            else if (upgradeLvl == 3)
            {
                upgradeButton3.GetComponent<Button>().interactable = false;
                maxedOutText.gameObject.SetActive(true);
            }

            Debug.Log("Upgrade unlocked!");
        }
        else
        {
            Debug.Log("Not enough skill points.");
        }
    }

    // Reset all upgrades in this upgrade tree.
    public void Reset()
    {
        maxedOutText.gameObject.SetActive(false);

        upgradeButton1.GetComponent<Button>().interactable = true;
        upgradeButton2.GetComponent<Button>().interactable = false;
        upgradeButton3.GetComponent<Button>().interactable = false;

        PlayerPrefs.SetInt(turretName, 0);
        upgradeLvl = 0;
        nextUpgradeCost = 1;
    }
}
