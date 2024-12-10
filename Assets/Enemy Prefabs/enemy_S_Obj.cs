using UnityEngine;

[CreateAssetMenu(fileName = "enemy_S_Obj", menuName = "Scriptable Objects/enemy_S_Obj")]
public class enemy_S_Obj : ScriptableObject
{
    [Header("Stats")]
    public float health;
    public float speed;
    public int damage;

    public int Vaule;

    [Header("Animations")]
    public Sprite sprite;
    public AnimationClip anim;
    //public an an;
}
