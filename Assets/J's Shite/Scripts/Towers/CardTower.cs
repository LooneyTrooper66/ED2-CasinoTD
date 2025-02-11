using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class CardTower : MasterTowerScript
{
    public float shotInterval;
    private tower_FindTarget findTarget;
    public Sprite[] cards;
    private SpriteRenderer sR;
    public GameObject bulletC;
    public GameObject shootPointC;
    private SpriteRenderer bulletSr;
    public int currentCard;
    float i = 0;


    private void Start()
    {
        findTarget = GetComponent<tower_FindTarget>();
        sR = GetComponent<SpriteRenderer>();
        //bulletSr = bulletC.GetComponent<SpriteRenderer>();

        currentCard = Random.Range(0, cards.Length);
        sR.sprite = cards[currentCard];
    }

    private void FixedUpdate()
    {
        i += 1 * Time.deltaTime;

        if (findTarget.potentialTargets.Count > 0)
        {
            findTarget.sortList();
            if (findTarget.Target != null && findTarget.Target == isActiveAndEnabled && findTarget.Target.transform.position.x >= -8)
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
                    i = 0;
                    /*bulletSr.sprite = cards[currentCard];
                    currentCard = Random.Range(0, cards.Length);
                    sR.sprite = cards[currentCard];*/
                    //base.Shoot(bulletC, shootPointC);
                    GameObject temp = Instantiate(bulletC, shootPointC.transform.position, shootPointC.transform.rotation);
                    temp.SetActive(true);
                    temp.GetComponent<SpriteRenderer>().sprite = cards[currentCard];
                    currentCard = Random.Range(0, cards.Length);
                    sR.sprite = cards[currentCard];
                    temp.GetComponent<ProjectileBehaviour>().Spawn(findTarget.Target.transform.position - shootPointC.transform.position);
                    findTarget.sortList();
                }
            }
        }
    }
}
