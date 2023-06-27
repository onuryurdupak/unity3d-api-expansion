using UnityEngine;

public static class MaterialExtensions
{
    public static Material GetMaterial(this MeshRenderer mr)
    {
        // Return shared material in edit mode to avoid resource leak error.
        return Application.isPlaying ? mr.material : mr.sharedMaterial;
    }
}