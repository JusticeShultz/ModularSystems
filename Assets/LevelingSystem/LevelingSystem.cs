using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelingSystem : MonoBehaviour
{
    public int Level = 1;
    public int SkillPoints = 0;

    public Text LevelDisplay;
    public Text SkillPointDisplay;
    public Image CurrentXPDisplay;

    public float BaselineXPMultipier = 100;

    public float GetNeededXP
    {
        get
        {
            return CurrentNeededXP;
        }
    }

    public float GetCurrentXP
    {
        get
        {
            return CurrentXP;
        }
    }

    private float CurrentXP = 0f;
    private float CurrentNeededXP = 0f;

    void Start()
    {
        UpdateXP();
    }

    public void UpdateXP()
    {
        int ohshitOhFuckjisikd = 0;

        CurrentNeededXP = Level * Level * BaselineXPMultipier;

        while (CurrentXP >= CurrentNeededXP)
        {
            CurrentXP -= CurrentNeededXP;

            CurrentNeededXP = Level * Level * BaselineXPMultipier;

            ++Level;
            ++SkillPoints;

            print("Leveled up to level " + Level);

            ++ohshitOhFuckjisikd;

            if (ohshitOhFuckjisikd > 100) break;
        }

        CurrentXPDisplay.fillAmount = CurrentXP / CurrentNeededXP;
        LevelDisplay.text = "Level: " + Level;
        SkillPointDisplay.text = "Skill Points: " + SkillPoints;
    }

    public void AddXP(float Amount)
    {
        CurrentXP += Amount;
        UpdateXP();
    }

    public void LoseXP(float Amount)
    {
        CurrentXP -= Amount;
        UpdateXP();
    }

    public void LevelUp()
    {
        ++Level;
        UpdateXP();
    }
    
    public void AddSkillPoint()
    {
        ++SkillPoints;
        UpdateXP();
    }
}