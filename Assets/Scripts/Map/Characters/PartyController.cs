using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Map.Characters
{
    public class PartyController : MonoBehaviour
    {
        private static readonly int isMoving = Animator.StringToHash("IsMoving");
        [SerializeField] private PlayerCharacter[] heroes;
        [SerializeField] private ParticleSystem changeVFX;

        private PlayerCharacter _currentCharacter;
        private int _currentCharacterIndex;
        private PlayerCharacterController _playerCharacterController;
        private PlayerInputActions _playerMapInput;

        private void Start()
        {
            ChangeCharacter();
        }

        private void Update()
        {
            _currentCharacter.Animator.SetBool(isMoving, _playerCharacterController.IsMoving);
        }

        private void OnDestroy()
        {
            _playerMapInput.Map.PreviousHero.performed -= ChoosePrevCharacter;
            _playerMapInput.Map.NextHero.performed -= ChooseNextCharacter;
            _playerMapInput.Map.Attack.performed -= Attack;
        }

        [Inject]
        public void Construct(PlayerInputActions playerInput, PlayerCharacterController playerCharacterController)
        {
            _playerCharacterController = playerCharacterController;
            _playerMapInput = playerInput;
            _playerMapInput.Map.PreviousHero.performed += ChoosePrevCharacter;
            _playerMapInput.Map.NextHero.performed += ChooseNextCharacter;
            _playerMapInput.Map.Attack.performed += Attack;
        }


        public PlayerCharacter[] GetHeroes()
        {
            return heroes;
        }

        private void Attack(InputAction.CallbackContext context)
        {
            _currentCharacter.GetWeapon().Attack();
        }

        private void ChoosePrevCharacter(InputAction.CallbackContext obj)
        {
            _currentCharacterIndex = (_currentCharacterIndex - 1) % heroes.Length;
            if (_currentCharacterIndex < 0)
                _currentCharacterIndex += heroes.Length;

            ChangeCharacter();
        }

        private void ChooseNextCharacter(InputAction.CallbackContext obj)
        {
            _currentCharacterIndex = (_currentCharacterIndex + 1) % heroes.Length;
            ChangeCharacter();
        }

        private void ChangeCharacter()
        {
            if (heroes[_currentCharacterIndex] == _currentCharacter)
                return;

            for (var i = 0; i < heroes.Length; i++)
                if (i != _currentCharacterIndex)
                {
                    heroes[i].Deactivate();
                }
                else
                {
                    heroes[i].Activate();
                    _currentCharacter = heroes[i];
                }

            changeVFX.Play();
        }
    }
}