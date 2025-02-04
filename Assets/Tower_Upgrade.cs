using System.Collections.Generic;
using UnityEngine;

public class Tower_Upgrade : MonoBehaviour
{
    [SerializeField] GameObject UpgradeBase;
    int i;
    SpriteRenderer UpgradeSprite;
    MoneyManager Cash;
    public Upgrade[] Upgrades;
    public tower_Type tType;
    //
    public enum tower_Type
    {
        Card,
        Roulet,
        Honse
    }


    [System.Serializable]
    public class Upgrade
    {
        public float UpgradeCost;
        public float AtkSpeedFlat;
        public float AtkSpeedMult;
        public float DmgFlat;
        public float DmgMult;
        public Color UpgradeColour;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cash = FindAnyObjectByType<MoneyManager>();
        UpgradeSprite = UpgradeBase.GetComponent<SpriteRenderer>();
        //Upgrades =
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Cash.playerMoney > Upgrades[i].UpgradeCost)
        {
            //update sprite to indicate 
            UpgradeSprite.color =  new (Mathf.PingPong(1,1),0,0,1);

        }

    }
    private void Update()
    {
        //set the upgrade vaules
        //flat upgarde then applie the mult 
        UpgradeSprite.color = Upgrades[i].UpgradeColour;
        //get tower type to applie upgrades
        switch (tType) // get the tower compoent and the extra vaules
        {
            case tower_Type.Card:

                break;
            case tower_Type.Roulet:

                break;
            case tower_Type.Honse:

                break;
            default:
                Debug.LogWarning("TYPE INVALID");
                break;
        }
        

        i++; //nextupgrade level
    }
}

