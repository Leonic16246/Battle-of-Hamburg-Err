using TMPro;
using UnityEngine;

public class UpgradesUI : MonoBehaviour
{
    int skillPoints = 0;
    public TextMeshProUGUI skillPointsText;
    
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
}
