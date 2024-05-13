using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(AudioSource))]
public class EyeInteractable : MonoBehaviour
{
    public bool IsHovered { get; set; }

    [SerializeField]
    private UnityEvent OnObjectHover;

    [SerializeField]
    private Material OnHoverActiveMaterial;

    [SerializeField]
    private Material OnHoverInactiveMaterial;

   // [SerializeField]
   // private AudioClip hoverSound;

    private MeshRenderer meshRenderer;
    // private AudioSource audioSource; 

    [SerializeField]

    private extOSC.Examples.SendNoteOnOver OscSend;

    private bool Isenter;
    


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
      //  audioSource = GetComponent<AudioSource>();
      
    }

    private void Update()
    {
        if (IsHovered && !Isenter)
        {
            OscSend.PlayNote();
            Isenter = true;
            if (meshRenderer.material != OnHoverActiveMaterial)
            {
                //  audioSource.PlayOneShot(hoverSound);
                
            }
            OnObjectHover?.Invoke();
            meshRenderer.material = OnHoverActiveMaterial;
        }
        else if (!IsHovered && Isenter)
        {
            meshRenderer.material = OnHoverInactiveMaterial;
            OscSend.StopNote();
            Isenter = false;
        }
    }

}
