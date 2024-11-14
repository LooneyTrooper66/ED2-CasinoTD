using UnityEngine;

public class Draggable : MonoBehaviour
{

    private float duration = 6f;
    private float elapsedTime;
    public Vector3 returnTo;
    public CardIconBehaviour cardController;


    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (cardController.isInPlace == false)
        {
            if (transform.position != returnTo)
            {
                float percentComp = elapsedTime / duration;
                transform.position = Vector3.Lerp(cardController.startPos, returnTo, percentComp);
            }
            else
            {
                cardController.isInPlace = true;
            }
        }
    }
}
