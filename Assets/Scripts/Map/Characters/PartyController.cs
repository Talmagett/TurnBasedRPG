using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Map.Characters
{
    public class PartyController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter[] heroes;
        [SerializeField] private ParticleSystem changeVFX;

        private PlayerInputActions _playerMapInput;
        private PlayerCharacter _currentCharacter;
        private static readonly int isMoving = Animator.StringToHash("IsMoving");

        private PlayerCharacterController _playerCharacterController;
        public PlayerCharacter[] GetHeroes() => heroes;
        [Inject]
        public void Construct(PlayerInputActions playerInput,PlayerCharacterController playerCharacterController)
        {
            _playerCharacterController = playerCharacterController;
            _playerMapInput = playerInput;
            _playerMapInput.Map.ChooseFirst.performed += ChooseFirstCharacter;
            _playerMapInput.Map.ChooseSecond.performed += ChooseSecondCharacter;
            _playerMapInput.Map.ChooseThird.performed += ChooseThirdCharacter;
            _playerMapInput.Map.ChooseFourth.performed += ChooseFourthCharacter;
            _playerMapInput.Map.Attack.performed += Attack;
        }

        private void OnDestroy()
        {
            _playerMapInput.Map.ChooseFirst.performed -= ChooseFirstCharacter;
            _playerMapInput.Map.ChooseSecond.performed -= ChooseSecondCharacter;
            _playerMapInput.Map.ChooseThird.performed -= ChooseThirdCharacter;
            _playerMapInput.Map.ChooseFourth.performed -= ChooseFourthCharacter;
            _playerMapInput.Map.Attack.performed -= Attack;
        }
        
        private void Attack(InputAction.CallbackContext obj)
        {
            _currentCharacter.GetWeapon().Attack();
        }

        private void Start()
        {
            //_currentCharacter = heroes[0];
            ChangeCharacter(1);
        }

        private void Update()
        {
            _currentCharacter.Animator.SetBool(isMoving,_playerCharacterController.IsMoving);
        }

        private void ChooseFirstCharacter(InputAction.CallbackContext obj)
        {
            ChangeCharacter(1);
        }
        private void ChooseSecondCharacter(InputAction.CallbackContext obj)
        {
            ChangeCharacter(2);
        }
        private void ChooseThirdCharacter(InputAction.CallbackContext obj)
        {
            ChangeCharacter(3);
        }
        private void ChooseFourthCharacter(InputAction.CallbackContext obj)
        {
            ChangeCharacter(4);
        }
        
        private void ChangeCharacter(int index)
        {
            var checkingCharacter = _currentCharacter;
            index--;
            if (index > heroes.Length-1 || index < 0)
                return;
            for (var i = 0; i < heroes.Length; i++)
            {
                if (i != index)
                    heroes[i].Deactivate();
                else
                {
                    heroes[i].Activate();
                    _currentCharacter = heroes[i];
                }
            }

            if (checkingCharacter == _currentCharacter)
                return;
            changeVFX.Play();
        }
    }
}