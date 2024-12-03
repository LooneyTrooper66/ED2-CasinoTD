using UnityEngine;

[CreateAssetMenu(fileName = "enemy_S_Obj", menuName = "Scriptable Objects/enemy_S_Obj")]
public class enemy_S_Obj : ScriptableObject
{
    [Header("Name")]
    public string enemyClass;
    [Header("Stats")]
    public float health;
    public float speed;
    public int damage;

    [Header("Animations")]
    public Sprite sprite;
    public Animation anim;
}
