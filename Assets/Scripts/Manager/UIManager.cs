using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Managers {
    public class UIManager : SingletonBehaviour<UIManager> {

        public GameObject canvasPrefab;
        public GameObject UICanvas { get; private set; }
        public GameObject DialogueUI { get => UICanvas.transform.Find ("DialogueBox").gameObject; }

        public void SetupCanvas () {
            UICanvas = Instantiate (canvasPrefab);
        }

        public string GetDialogueName () {
            return DialogueUI.transform.Find ("DialogueNameText").GetComponent<TextMeshProUGUI> ().text;
        }
        public void SetDialogueName (string name) {
            DialogueUI.transform.Find ("DialogueNameText").GetComponent<TextMeshProUGUI> ().text = name;
        }
        public string GetDialogueText () {
            return DialogueUI.transform.Find ("DialogueText").GetComponent<TextMeshProUGUI> ().text;
        }
        public void SetDialogueText (string text) {
            DialogueUI.transform.Find ("DialogueText").GetComponent<TextMeshProUGUI> ().text = text;
        }
    }
}