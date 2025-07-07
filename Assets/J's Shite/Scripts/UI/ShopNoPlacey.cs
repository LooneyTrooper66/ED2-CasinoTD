using UnityEngine;
using System.Collections;

public class ShopNoPlacey : MonoBehaviour
{
    private Vector3 onScreen = new Vector3(-6.78f, 0, -1);
    bool hasBeenDeactivated = true;
    bool boardSpinning = true;
    public GameObject cover;


    private void Start()
    {
        cover.SetActive(true);
    }

    private void Update()
    {
        if (boardSpinning == false)
        {
            if (gameObject.transform.position == onScreen && hasBeenDeactivated == true)
            {
                cover.SetActive(true);
                hasBeenDeactivated = false;
            }
            if (gameObject.transform.position != onScreen && hasBeenDeactivated == false)
            {
                StartCoroutine(TurnOff());
            }
        }
    }

    IEnumerator TurnOff()
    {
        hasBeenDeactivated = true;
        yield return new WaitForSecondsRealtime(0.5f); // needs to wait as can place roulette tower wrong otherwise which messes up placer
        cover.SetActive(false);
    }

    // to be accessed in other script
    public void ActivateStopper()
    {
        boardSpinning = true;
        StopCoroutine(TurnOff());
        cover.SetActive(true);
        hasBeenDeactivated = false;
    }

    public void DeactivateStopper()
    {
        boardSpinning = false;
        cover.SetActive(false);
        hasBeenDeactivated = true;
    }
}
