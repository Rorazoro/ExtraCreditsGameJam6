using Assets.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Entities {

    public class Player : MonoBehaviour {

        private Animator anim;
        public Animator slashAnimator;

        public GameObject AudioManager;
        private SpriteRenderer spriteRenderer = null;
        private Rigidbody2D rb = null;

        private PlayerInput playerInput = null;
        private IInputHandler playerInputHandler = null;
        private EntityMotor entityMotor = null;
        private PlayerInteractHandler playerInteractHandler = null;
        private PlayerCutHandler playerCutHandler = null;

        private Vector3 scale;

        [SerializeField]
        private float speed = 3f;

        private void Awake () {
            scale = transform.localScale;
            anim = GetComponent<Animator> ();
            spriteRenderer = GetComponent<SpriteRenderer> ();
            rb = GetComponent<Rigidbody2D> ();
            playerInput = GetComponent<PlayerInput> ();

            playerInputHandler = new PlayerInputHandler (playerInput);
            entityMotor = new EntityMotor (playerInputHandler, rb, speed);
            playerInteractHandler = new PlayerInteractHandler (playerInputHandler);
            playerCutHandler = new PlayerCutHandler (playerInputHandler);
        }

        private void FixedUpdate () {
            entityMotor.Tick ();
            playerInteractHandler.Tick ();
            playerCutHandler.Tick (gameObject.transform.position);

            if (playerInputHandler.isCut) {
                //Cut (For now)
                slashAnimator.SetTrigger ("Cut");
                //AudioManager.GetComponent<CharacterAudio> ().Cut ();
            }
            if (playerInputHandler.movement != new Vector2 (0, 0)) {
                anim.SetBool ("Moving", true);
            } else {
                anim.SetBool ("Moving", false);
            }

            if (playerInputHandler.movement.x < -0.5) {
                transform.localScale = new Vector3 (scale.x * -1, transform.localScale.y, transform.localScale.z);
            } else if (playerInputHandler.movement.x > 0.5) {
                transform.localScale = new Vector3 (scale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        private void OnTriggerEnter2D (Collider2D other) => playerInteractHandler?.OnTriggerEnter2D (other);
        private void OnTriggerExit2D (Collider2D other) => playerInteractHandler?.OnTriggerExit2D (other);

        public void ToggleInputDebugLog (bool value) {
            if (playerInputHandler != null) {
                playerInputHandler.EnableDebugging = value;
            }
        }

        //Game Audio
        public void Footstep () {
            AudioManager.GetComponent<CharacterAudio> ().FootStep ();
        }
        public void FootstepLow () {
            AudioManager.GetComponent<CharacterAudio> ().FootStepLow ();
        }
    }
}