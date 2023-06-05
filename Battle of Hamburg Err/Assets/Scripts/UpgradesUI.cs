using TMPro;
using UnityEngine;

public class UpgradesUI : MonoBehaviour
{
    int skillPoints = 0;
    public TextMeshProUGUI skillPointsText;
    public GameObject resetPrompt;

    [Header("Upgrade Trees")]
    public UpgradeTree burgerTurretTree;
    public UpgradeTree sushiLauncherTree;
    public UpgradeTree donutLaserTree;
    
    // Set the # of skill points from last game.
    void Start()
    {
        if (PlayerPrefs.HasKey("skill points"))
        {
            skillPoints = PlayerPrefs.GetInt("skill points");
        }
        skillPointsText.text = "Skill points: " + skillPoints;
    }

    public int GetSkillPoints()
    {
        return skillPoints;
    }
    
    // Update skill points text + PlayerPrefs value
    public void SetSkillPoints(int skillPoints)
    {
        this.skillPoints = skillPoints;
        skillPointsText.text = "Skill points: "+ skillPoints;
        PlayerPrefs.SetInt("skill points", skillPoints);
    }

    public void PromptReset()
    {
        resetPrompt.SetActive(true);
    }

    // Reset all upgrade trees.
    public void ConfirmReset()
    {
        burgerTurretTree.Reset();
        sushiLauncherTree.Reset();
        donutLaserTree.Reset();

        resetPrompt.SetActive(false);
    }

    public void CancelReset()
    {
        resetPrompt.SetActive(false);
    }
}
