using UnityEngine;

public class Draggable : MonoBehaviour
{
    public Transform thisGO;
    private float speed = 40f;
    [SerializeField] private Vector3 returnTo;
    public CardIconBehaviour cardController;


    private void Update()
    {
        switch (gameObject.tag)
        {
            case "card":
                if (cardController.cardInPlace == false)
                {
                    if (thisGO.position != returnTo)
                    {
                        thisGO.position = Vector3.MoveTowards(thisGO.position, returnTo, speed * Time.deltaTime);
                    }
                    else
                    {
                        cardController.cardInPlace = true;
                    }
                }
                return;
            case "roulette":
                if (cardController.rouletteInPlace == false)
                {
                    if (thisGO.position != returnTo)
                    {
                        thisGO.position = Vector3.MoveTowards(thisGO.position, returnTo, speed * Time.deltaTime);
                    }
                    else
                    {
                        cardController.rouletteInPlace = true;
                    }
                }
                return;
            case "horse":
                if (cardController.horseInPlace == false)
                {
                    if (thisGO.position != returnTo)
                    {
                        thisGO.position = Vector3.MoveTowards(thisGO.position, returnTo, speed * Time.deltaTime);
                    }
                    else
                    {
                        cardController.horseInPlace = true;
                    }
                }
                return;
        }
    }
}
