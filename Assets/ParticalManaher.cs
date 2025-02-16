using UnityEngine;

public class ParticalManaher : MonoBehaviour
{
    bool StartPs;
    public ParticleSystem[] PS;
    public GameObject background;
    public Transform bglock;
    public bool dubug;
    float i;
    Transform ogpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        i = 0;
        ogpos = background.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (dubug)
        {
            startP();
        }

        if (StartPs)
        {
            i += (Time.deltaTime * 0.5f);
            background.transform.position = Vector3.Lerp(ogpos.position, bglock.position, (i - 5) / 3);
        }
    }

    public void startP()
    {
        foreach (ParticleSystem Ps in PS)
        {
            Ps.Play();
            StartPs = true;
        }
    }
}
