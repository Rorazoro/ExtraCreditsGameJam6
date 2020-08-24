using UnityEngine;

[CreateAssetMenu (fileName = "PlantScriptableObject", menuName = "ExtraCreditsGameJam6/PlantScriptableObject", order = 0)]
public class PlantScriptableObject : ScriptableObject {

    public int maxHealth;
    public int health;
    public float baseGrowthTime;

    public PlantType plantType;

    public Sprite[] stageSprites = new Sprite[4];
}