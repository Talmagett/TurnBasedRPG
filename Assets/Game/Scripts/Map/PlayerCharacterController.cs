using UnityEngine;

namespace Map
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed;
        
        void Update()
        {
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");
            characterController.Move(new Vector3(hor,0,ver)*speed*Time.deltaTime);
        }
    }
}
