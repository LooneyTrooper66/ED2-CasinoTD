using UnityEngine;

public class CardTower : MasterTowerScript
{
    public float shotInterval;
    private tower_FindTarget findTarget;
    public Sprite[] cards;
    private SpriteRenderer sR;
    public GameObject bullet;
    public GameObject shootPoint;
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
            findTarget.sortList();
            if (findTarget.Target != null)
            {
                Vector3 targ = findTarget.Target.transform.position;
                targ.z = 0f;

                Vector3 objectPos = transform.position;
                targ.x = targ.x - objectPos.x;
                targ.y = targ.y - objectPos.y;

                float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                if (i > shotInterval)
                {
                    bulletSr.sprite = cards[currentCard];
                    currentCard = Random.Range(0, cards.Length);
                    sR.sprite = cards[currentCard];
                    base.Shoot(bullet, shootPoint);

                    findTarget.sortList();
                    i = 0;
                }
            }
        }
    }
}
