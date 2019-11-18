using UnityEngine;

[CreateAssetMenu(fileName ="New Ghost", menuName ="Ghosts/New Ghost")]
public class Ghost : ScriptableObject
{
    public string ghostName = "New Item";
    public Sprite icon = null;
    public bool bood = true;
    public float angle = 40f;
    public float range = 10f;
}
