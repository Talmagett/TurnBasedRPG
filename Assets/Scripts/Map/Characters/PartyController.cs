using Actors;
using Atomic.Elements;
using Atomic.Objects;
using Map.Interactions.Environment;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Map.Characters
{
    public class PartyController : MonoBehaviour
    {
        private static readonly int isMoving = Animator.StringToHash("IsMoving");
        [SerializeField] private MapActor[] heroes;
        [SerializeField] private ParticleSystem changeVFX;

        public MapActor CurrentCharacter { get; private set; }
        
        private int _currentCharacterIndex;
        private PlayerCharacterController _playerCharacterController;
        private PlayerInputActions _playerMapInput;

        private void Start()
        {
            ChangeCharacter();
        }

        private void Update()
        {
            if(CurrentCharacter.TryGet("Animator",out AtomicVariable<Animator> animator))
                animator.Value.SetBool(isMoving, _playerCharacterController.IsMoving);
        }

        private void OnDestroy()
        {
            _playerMapInput.Map.PreviousHero.performed -= ChoosePrevCharacter;
            _playerMapInput.Map.NextHero.performed -= ChooseNextCharacter;
        }

        [Inject]
        public void Construct(PlayerInputActions playerInput, PlayerCharacterController playerCharacterController)
        {
            _playerCharacterController = playerCharacterController;
            _playerMapInput = playerInput;
            _playerMapInput.Map.PreviousHero.performed += ChoosePrevCharacter;
            _playerMapInput.Map.NextHero.performed += ChooseNextCharacter;
        }


        public MapActor[] GetHeroes()
        {
            return heroes;
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
            if (heroes[_currentCharacterIndex] == CurrentCharacter)
                return;

            for (var i = 0; i < heroes.Length; i++)
                if (i != _currentCharacterIndex)
                {
                    heroes[i].gameObject.SetActive(false);
                }
                else
                {
                    heroes[i].gameObject.SetActive(true);
                    CurrentCharacter = heroes[i];
                }

            changeVFX.Play();
        }
    }
}