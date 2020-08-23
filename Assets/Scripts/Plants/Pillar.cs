using UnityEngine;

public class Pillar : MonoBehaviour {
    public int overgrownStage;
    public int overgrownMaxStage = 6;
    public bool isOvergrown;
    public Sprite overgrownSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer> ();

        overgrownStage = 0;
    }

    private void Update () {
        if (overgrownStage >= overgrownMaxStage && !isOvergrown) {
            spriteRenderer.sprite = overgrownSprite;
            isOvergrown = true;
            LevelManager.Instance.IncreaseOvergrowth ();
        }
    }

    public void IncreaseOvergrowth () {
        overgrownStage++;
    }

    public void DecreaseOvergrowth () {
        overgrownStage--;
    }
}