using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Classes))]
public class ClassesEditor : Editor
{
    private int totalPoints = 50;

    public override void OnInspectorGUI()
    {
        Classes classes = (Classes)target;

        EditorGUILayout.LabelField("Class Settings", EditorStyles.boldLabel);
        classes.className = EditorGUILayout.TextField("Class Name", classes.className);
        //classes.classType = (Class)EditorGUILayout.EnumPopup("Class Type", classes.classType);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Stats", EditorStyles.boldLabel);

        int usedPoints = classes.baseHealth + classes.baseMana + classes.baseAttack +
                         classes.baseDefense + classes.baseSpeed + classes.baseCritChance;

        int remainingPoints = totalPoints - usedPoints;

        EditorGUILayout.HelpBox($"Pontos restantes: {remainingPoints}", MessageType.Info);
        GUI.enabled = remainingPoints > 0;

        classes.baseHealth = DrawStatSlider("Health", classes.baseHealth, ref remainingPoints);
        classes.baseMana = DrawStatSlider("Mana", classes.baseMana, ref remainingPoints);
        classes.baseAttack = DrawStatSlider("Attack", classes.baseAttack, ref remainingPoints);
        classes.baseDefense = DrawStatSlider("Defense", classes.baseDefense, ref remainingPoints);
        classes.baseSpeed = DrawStatSlider("Speed", classes.baseSpeed, ref remainingPoints);
        classes.baseCritChance = DrawStatSlider("Crit Chance", classes.baseCritChance, ref remainingPoints);

        GUI.enabled = true;

        EditorGUILayout.Space();
        if (GUILayout.Button("Reset Stats"))
        {
            classes.baseHealth = 0;
            classes.baseMana = 0;
            classes.baseAttack = 0;
            classes.baseDefense = 0;
            classes.baseSpeed = 0;
            classes.baseCritChance = 0;
        }

        classes.totalPoints = totalPoints;
        EditorUtility.SetDirty(classes);
    }

    private int DrawStatSlider(string label, int currentValue, ref int remainingPoints)
    {
        int newValue = EditorGUILayout.IntSlider(label, currentValue, 0, 100);
        int difference = newValue - currentValue;
        if(remainingPoints - difference >= 0)
        {
            remainingPoints -= difference;
            return newValue;
        }
        return currentValue;
    }
}
