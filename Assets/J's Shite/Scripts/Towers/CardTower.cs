using UnityEngine;

public class CardTower : MasterTowerScript
{
    public float shotInterval;
    private tower_FindTarget findTarget;
    public Sprite[] cards;
    private SpriteRenderer sR;
    public GameObject bullet;
    private SpriteRenderer bulletSr;
    public int currentCard;
    int i = 0;


    private void Start()
    {
        findTarget = GetComponent<tower_FindTarget>();
        sR = GetComponent<SpriteRenderer>();
        bulletSr = bullet.GetComponent<SpriteRenderer>();

        currentCard = Random.Range(0, cards.Length);
        sR.sprite = cards[currentCard];
    }

    private void FixedUpdate()
    {
        i++;

        if (findTarget.potentialTargets.Count > 0)
        {
            transform.LookAt(findTarget.Target.transform);

            if (i > shotInterval)
            {
                bulletSr.sprite = cards[currentCard];
                currentCard = Random.Range(0, cards.Length);
                sR.sprite = cards[currentCard];

                findTarget.sortList();
                i = 0;
            }
        }
    }
}
