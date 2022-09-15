using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
   //[Space(12)]              //make space in Inspector
   [Header("Automat")]        //make Name in Inspector
    public int NumberOfBullets;
    public Text BulletText;
    public PlayerArmory PlayerArmory;

    public override void Shot()
    {
        base.Shot();
        NumberOfBullets -= 1;
        UpdateText();
        if(NumberOfBullets == 0)
        {
            PlayerArmory.TakeGunByIndex(0);
        }
    }

    void UpdateText() => BulletText.text = "Bullets: " + NumberOfBullets.ToString();
    

    public override void Activate()
    {
        base.Activate();
        BulletText.enabled = true;
        UpdateText();
    }
    public override void Deactivate()
    {
        base.Deactivate();
        BulletText.enabled = false;
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);
        NumberOfBullets += numberOfBullets;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
    }
}
