using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
    public static string GetRelationshipLevel(int friendship)
    {
        if (friendship < 0)
            return "Dislikes You";

        if (friendship < 20)
            return "Acquaintance";

        if (friendship < 50)
            return "Friend";

        return "Close Friend";
    }
}