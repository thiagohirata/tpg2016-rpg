using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName ="AttackType", menuName = "RPGFight/New Attack Type")]
public class AttackType : ScriptableObject {

    public string attackName;
    public DamageType damageType;
    public int damageAmount;
    public int manaCost;
    public string animationTrigger;
}
