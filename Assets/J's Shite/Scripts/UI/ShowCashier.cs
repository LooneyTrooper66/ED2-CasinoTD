using UnityEngine;
using UnityEngine.UI;

public class ShowCashier : MonoBehaviour
{
    [SerializeField] Button showCashier;
    public GameObject cashier;
    public Transform goTo;
    public Vector3 onScreenCashier;
    public Vector3 offScreenCashier;
    [SerializeField] private AudioClip clip;
    AudioManager audioM;


    private void Start()
    {
        showCashier.onClick.AddListener(cashierShow);
        audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        if (goTo.position == offScreenCashier)
        {
            audioM.PlaySFX(clip);
            goTo.position = onScreenCashier;
        }
        else
        {
            goTo.position = offScreenCashier;
        }
    }
}
