using UnityEngine;
using System.Collections;

public class ShopNoPlacey : MonoBehaviour
{
    private Vector3 offScreen = new Vector3(-13.13f, 0, 1);
    bool hasBeenDeactivated = false;
    public GameObject cover;


    private void Update()
    {
        if (gameObject.transform.position != offScreen)
        {
            cover.SetActive(true);
            hasBeenDeactivated = false;
        }
        else
        {
            if (hasBeenDeactivated == false)
            {
                StartCoroutine(TurnOff());
            }
        }
    }

    IEnumerator TurnOff()
    {
        hasBeenDeactivated = true;
        yield return new WaitForSecondsRealtime(0.8f); // needs to wait as can place roulette tower wrong otherwise which messes up placer
        cover.SetActive(false);
    }
}
