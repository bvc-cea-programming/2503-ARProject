using UnityEngine;

namespace LeoEsguerra
{
    public class CharacterController : MonoBehaviour
    {
        private Animator animator;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if(animator != null)
                {
                    animator.SetBool("IsDancing", true);
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if(animator != null)
                {
                    animator.SetBool("IsDancing", false);
                }
            }
        }
    }
}