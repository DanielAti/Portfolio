using UnityEngine;

//Ponemos este Script en un Quad.
//Script para modificar el fondo, y que vaya girando poco a poco, simulando movimiento.
// IMPORTANTE: Si se usa un Material, usando una imagen, muy importante poner "Warp Mode: Repeat:
public class BackGround : MonoBehaviour
{
    public float scroll_speed = 0.1f;

    private MeshRenderer meshRenderer;

    private Vector2 saved_Offset;


    //"_MainText" Es la principal textura difusa. También se puede acceder a través de la propiedad mainTexture.
    // Otra propiedad es "_BumpMap"
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        saved_Offset = meshRenderer.sharedMaterial.GetTextureOffset("_MainTex");
    }
    void Update()
    {
        float x = Time.time * scroll_speed;

        //Ponemos que solo cambie el Vector X

        Vector2 offset = new Vector2(x, 0);

        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", saved_Offset);
    }
}
