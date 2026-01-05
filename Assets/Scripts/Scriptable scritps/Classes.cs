using UnityEngine;
public enum Class
{
    Warrior,
    Mage,
    Healer,
    Archer,
    God,
    Demon,

}

[CreateAssetMenu(fileName = "New Class", menuName = "Classes")]
public class Classes : ScriptableObject
{

    public string className;
    //public Class classType;
    
    [Range(0,100)] public int baseHealth;
    [Range(0,100)] public int baseMana;
    [Range(0,100)] public int baseAttack;
    [Range(0,100)] public int baseDefense;
    [Range(0,100)] public int baseSpeed;
    [Range(0,100)] public int baseCritChance;

    [HideInInspector] public int totalPoints = 50;

    public Sprite charImage;

}
