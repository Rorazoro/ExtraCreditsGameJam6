using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Managers {
    public class DialogueManager : MonoBehaviour {
        public TextMeshProUGUI dialogueText;
        private Queue<string> sentences;

        private void Awake () {
            sentences = new Queue<string> ();
        }

        public void StartDialogue (DialogueContainer container) {
            Dialogue dialogue = container.dialogue;
            dialogueText = container.dialogueText;

            sentences.Clear ();
            foreach (string s in dialogue.sentences) {
                sentences.Enqueue (s);
            }
            DisplayNextSentence ();
            container.CloseButton.SetActive (true);
        }

        public void DisplayNextSentence () {
            if (sentences.Count == 0) {
                EndDialogue ();
                return;
            }

            string sentence = sentences.Dequeue ();
            StopAllCoroutines ();
            StartCoroutine (TypeSentence (sentence));
        }

        IEnumerator TypeSentence (string sentence) {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray ()) {
                dialogueText.text += letter;
                yield return new WaitForSeconds (0.05f);
            }

        }

        public void EndDialogue () {
            UIManager.Instance.DialogueUI.SetActive (false);
        }
    }
}