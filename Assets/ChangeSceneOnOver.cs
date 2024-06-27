using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using UnityEngine.SceneManagement;

public class ChangeSceneOnOver : MonoBehaviour
{

    public bool IsHovered { get; set; }
    public bool OnMouseEnterActive = false;

    [SerializeField]
    private SceneAsset GotoScene;

    [SerializeField]
    private UnityEvent OnObjectHover;

    [SerializeField]
    private Material OnHoverActiveMaterial;

    [SerializeField]
    private Material OnHoverInactiveMaterial;

    public TMPro.TextMeshProUGUI UIText;

    private MeshRenderer meshRenderer;

    private bool Isenter = false;

    private int ind = -1;

    private void OnValidate()
    {
        gameObject.name = "Goto: " + GotoScene.name;
        UIText.text = GotoScene.name;

    }

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsHovered && !Isenter)
        {
            OnStartHover();
        }
        else if (!IsHovered && Isenter)
        {
            OnEndHover();
        }
        
    }

    private void OnMouseEnter()
    {
        if (!OnMouseEnterActive) return;
        IsHovered = true;
        //OnStartHover();
    }


    private void OnMouseExit()
    {
        if (!OnMouseEnterActive) return;
        IsHovered = false;
        //OnEndHover();
    }

    void changeScene()
    {
        SceneManager.LoadScene(GotoScene.name);
    }

    void OnStartHover()
    {
        Isenter = true;
        OnObjectHover?.Invoke();
       
        if (meshRenderer.material != OnHoverActiveMaterial)
        {
            ind = 0;
            StartCoroutine(waitCoroutine());
            UIText.text = GotoScene.name + " " + (5 - ind).ToString();
        }
        meshRenderer.material = OnHoverActiveMaterial;
    }

    void OnEndHover()
    {
        Debug.Log("Onendhover");
        meshRenderer.material = OnHoverInactiveMaterial;
        Isenter = false;
        ind = -1;
    }

    IEnumerator waitCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        for (int i=0; i<6; i++)
        {
            Debug.Log("ind=" + ind);
            //yield on a new YieldInstruction that waits for 1 seconds.
            yield return new WaitForSeconds(1);

            if (ind >= 5)
            {
                SceneManager.LoadScene(GotoScene.name);
            }
            else if (ind >= 0)
            {

                ind++;
                UIText.text = GotoScene.name + " " + (5 - ind).ToString();
            }

            else
            {
                UIText.text = GotoScene.name;
                break;
            }
        }

        

        //Print the time when the function ends
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
