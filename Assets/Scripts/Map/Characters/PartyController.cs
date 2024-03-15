using Map.Interactions.Environment;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Map.Characters
{
    public class PartyController : MonoBehaviour
    {
        private static readonly int isMoving = Animator.StringToHash("IsMoving");
        [SerializeField] private BaseCharacter[] heroes;
        [SerializeField] private ParticleSystem changeVFX;

        private BaseCharacter _currentCharacter;
        private Weapon _currentWeapon;
        
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


        public BaseCharacter[] GetHeroes()
        {
            return heroes;
        }

        private void Attack(InputAction.CallbackContext context)
        {
            _currentWeapon.Attack();
        }

        private void ChoosePrevCharacter(InputAction.CallbackContext obj)
        {
            _currentCharacterIndex--;
            
            if(_currentCharacterIndex<0)
                _currentCharacterIndex += heroes.Length;

            ChangeCharacter();
        }

        private void ChooseNextCharacter(InputAction.CallbackContext obj)
        {
            _currentCharacterIndex++;
            _currentCharacterIndex %= heroes.Length;
            ChangeCharacter();
        }

        private void ChangeCharacter()
        {
            if (heroes[_currentCharacterIndex] == _currentCharacter)
                return;

            for (var i = 0; i < heroes.Length; i++)
                if (i != _currentCharacterIndex)
                {
                    heroes[i].gameObject.SetActive(false);
                }
                else
                {
                    heroes[i].gameObject.SetActive(true);
                    _currentCharacter = heroes[i];
                }

            _currentWeapon = _currentCharacter.GetComponent<Weapon>();
            changeVFX.Play();
        }
    }
}