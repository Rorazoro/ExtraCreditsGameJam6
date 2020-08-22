using Assets.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Entities {
    public class Player : MonoBehaviour {

        public GameObject audioManager;
        private SpriteRenderer spriteRenderer = null;
        private Rigidbody2D rb = null;

        private PlayerInput playerInput = null;
        private IInputHandler playerInputHandler = null;
        private EntityMotor entityMotor = null;
        private PlayerInteractHandler playerInteractHandler = null;

        [SerializeField]
        private float speed = 3f;

        private void Awake () {
            spriteRenderer = GetComponent<SpriteRenderer> ();
            rb = GetComponent<Rigidbody2D> ();
            playerInput = GetComponent<PlayerInput> ();

            playerInputHandler = new PlayerInputHandler (playerInput);
            entityMotor = new EntityMotor (playerInputHandler, rb, speed);
            playerInteractHandler = new PlayerInteractHandler (playerInputHandler);
        }

        private void Update () {
            playerInputHandler.ReadValue ();
            entityMotor.Tick ();
            playerInteractHandler.Tick ();
        }

        private void OnTriggerEnter2D (Collider2D other) => playerInteractHandler?.OnTriggerEnter2D (other);
        private void OnTriggerExit2D (Collider2D other) => playerInteractHandler?.OnTriggerExit2D (other);

        // public void InitializePlayer (PlayerConfig config) {
        //     playerConfig = config;
        //     spriteRenderer.sprite = playerConfig.playerSprite;

        //     playerInputHandler = new PlayerInputHandler (playerConfig.playerInput);
        //     entityMotor = new EntityMotor (playerInputHandler, rb, playerConfig.Speed);
        //     playerAnimator = new PlayerAnimator (playerInputHandler, animator);
        //     playerHealthSystem = new PlayerHealthSystem (UIManager.Instance.GetPlayerHealthUI (playerConfig.playerIndex), playerConfig.MaxHealth);
        // }

        public void ToggleInputDebugLog (bool value) {
            if (playerInputHandler != null) {
                playerInputHandler.EnableDebugging = value;
            }
        }
    }
}