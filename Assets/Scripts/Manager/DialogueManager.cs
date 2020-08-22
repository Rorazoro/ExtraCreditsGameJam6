using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Managers {
    public class DialogueManager : SingletonBehaviour<DialogueManager> {

        private Queue<string> sentences;

        private void Awake () {
            sentences = new Queue<string> ();
        }

        public void StartDialogue (Dialogue dialogue) {
            UIManager.Instance.SetDialogueName (dialogue.name);

            sentences.Clear ();
            foreach (string s in dialogue.sentences) {
                sentences.Enqueue (s);
            }
            DisplayNextSentence ();
            UIManager.Instance.DialogueUI.SetActive (true);
        }

        public void DisplayNextSentence () {
            if (sentences.Count == 0) {
                EndDialogue ();
                return;
            }

            string sentence = sentences.Dequeue ();
            UIManager.Instance.SetDialogueText (sentence);
        }

        public void EndDialogue () {
            UIManager.Instance.DialogueUI.SetActive (false);
        }
    }
}