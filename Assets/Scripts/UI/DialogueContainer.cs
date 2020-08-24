using Assets.Managers;
using TMPro;
using UnityEngine;

public class DialogueContainer : MonoBehaviour {

    public Dialogue dialogue;

    public TextMeshProUGUI dialogueText;
    public GameObject CloseButton;

    public void ReturnToMainMenu () {
        SceneLoader.Instance.LoadScene (Scenes.MainMenu, 0f, null);
    }
}