using UnityEngine;
using UnityEngine.UI;

public class ShowCashier : MonoBehaviour
{
    [SerializeField] Button showCashier;
    public GameObject cashier;
    public Transform goTo;


    private void Start()
    {
        showCashier.onClick.AddListener(cashierShow);
    }

    private void FixedUpdate()
    {
        if (transform.position != goTo.position)
        {
            cashier.transform.position = Vector3.MoveTowards(cashier.transform.position, goTo.position, 50 * Time.deltaTime);
        }
    }

    public void cashierShow()
    {
        goTo.position = new Vector3(6.95f, -1.75f, -1);
    }
}
