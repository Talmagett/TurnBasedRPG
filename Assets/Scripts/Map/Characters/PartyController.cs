using System;
using UnityEngine;
using Zenject;

namespace Map.Characters
{
    public class PartyController : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter[] playerCharacter;
        [SerializeField] private ParticleSystem changeVFX;
        
        private PlayerMapInput _playerMapInput;
        private PlayerCharacter _currentCharacter;
        private static readonly int isMoving = Animator.StringToHash("IsMoving");

        [Inject]
        public void Construct(PlayerMapInput playerMapInput)
        {
            _playerMapInput = playerMapInput;
            _playerMapInput.OnCharacterChosed += ChangeCharacter;
            _playerMapInput.OnAttack += Attack;
        }

        private void OnDestroy()
        {
            _playerMapInput.OnCharacterChosed -= ChangeCharacter;
            _playerMapInput.OnAttack -= Attack;
        }
        
        private void Attack()
        {
            _currentCharacter.GetWeapon().Attack();
        }

        private void Awake()
        {
            _currentCharacter = playerCharacter[0];
        }

        private void Update()
        {
            _currentCharacter.Animator.SetBool(isMoving,_playerMapInput.MoveDir!=Vector3.zero);
        }

        private void ChangeCharacter(int index)
        {
            var checkingCharacter = _currentCharacter;
            index--;
            if (index > playerCharacter.Length-1 || index < 0)
                return;
            for (var i = 0; i < playerCharacter.Length; i++)
            {
                if (i != index)
                    playerCharacter[i].Deactivate();
                else
                {
                    playerCharacter[i].Activate();
                    _currentCharacter = playerCharacter[i];
                }
            }

            if (checkingCharacter == _currentCharacter)
                return;
            changeVFX.Play();
        }
    }
}