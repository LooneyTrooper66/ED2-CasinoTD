using System.Collections.Generic;
using UnityEngine;

public class Tower_Upgrade : MonoBehaviour
{
    [SerializeField] GameObject UpgradeBase;
    [SerializeField]int i;
    SpriteRenderer UpgradeSprite;
    MoneyManager Cash;
    public Upgrade[] Upgrades;
    public tower_Type tType;
    MouseFollow Mf;
    //
    Color col;
    public enum tower_Type
    {
        Card,
        Roulet,
        Honse
    }


    [System.Serializable]
    public class Upgrade
    {
        public int UpgradeCost;
        public float AtkSpeedFlat;
        public float AtkSpeedMult = 1;
        public float DmgFlat;
        public float DmgMult = 1;
        public int Pierce;
        public float VariableStat = 1; // this one will do diffrent things such as number of cards or roulet ball size
        public Color UpgradeColour;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cash = FindAnyObjectByType<MoneyManager>();
        UpgradeSprite = UpgradeBase.GetComponent<SpriteRenderer>();
        col = Color.white;

        if (Mf == null)
        {
            Mf = FindFirstObjectByType<MouseFollow>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (i < Upgrades.Length && Cash.playerMoney > Upgrades[i].UpgradeCost)
        {
            //update sprite to indicate 
            UpgradeSprite.color =  new (Mathf.PingPong(1,1),0,0,1);

        }
        else if (UpgradeSprite.color != col)
        {
            UpgradeSprite.color = col;
        }



    }
    public void Upgrade_check()//trigger upgrade check
    {
        //Debug.Log("Upgrade");
        if (i < Upgrades.Length && Cash.playerMoney > Upgrades[i].UpgradeCost)
        {
            UpgradeTower();
        }
    }

    void UpgradeTower()
    {
        //set the upgrade vaules
        //flat upgarde then applie the mult 
        //get tower type to applie upgrades
        col = Upgrades[i].UpgradeColour;
        Cash.playerMoney -= Upgrades[i].UpgradeCost;
        switch (tType) // get the tower compoent and the extra vaules
        {
            case tower_Type.Card:
                CardTower ct = GetComponent<CardTower>();
                ct.shotInterval -= Upgrades[i].AtkSpeedFlat;
                ct.shotInterval *= Upgrades[i].AtkSpeedMult;

                ProjectileBehaviour CBB = transform.GetChild(0).GetComponent<ProjectileBehaviour>();
                CBB.damage += Upgrades[i].DmgFlat;
                CBB.damage *= Upgrades[i].DmgMult;
                break;     
            case tower_Type.Roulet:
                RouletteTower rt = GetComponent<RouletteTower>();
                rt.shotInterval -= Upgrades[i].AtkSpeedFlat;
                rt.shotInterval *= Upgrades[i].AtkSpeedMult;

                GameObject ball = transform.GetChild(0).gameObject;
                ball.transform.localScale = ball.transform.localScale * Upgrades[i].VariableStat;

                ProjectileBehaviour ballPb = ball.GetComponent<ProjectileBehaviour>();
                ballPb.peirce += Upgrades[i].Pierce;
                ballPb.damage += Upgrades[i].DmgFlat;
                ballPb.damage = ballPb.damage * Upgrades[i].DmgMult;
                break;
            case tower_Type.Honse:
                HorseTower Hrt = GetComponent<HorseTower>();
                Hrt.shotInterval -= Upgrades[i].AtkSpeedFlat;
                Hrt.shotInterval *= Upgrades[i].AtkSpeedMult;

                //i dont think i can upgrade the horse with the current method! :£ i shot myself in the foot like someone who cant aim and just shot themselves in the foot 
                break;
            default:
                Debug.LogWarning("TYPE INVALID");
                break;
        }

        Mf.triggerPartical();
        i++; //nextupgrade level
    }
}

