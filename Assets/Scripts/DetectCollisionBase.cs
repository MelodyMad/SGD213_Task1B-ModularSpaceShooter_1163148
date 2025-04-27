using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DetectCollisionBase handles the types of collision and triggers to determine what actions are then taken,
/// based on the tags that are applied and created within unity
/// </summary>
public class DetectCollisionBase : MonoBehaviour
{
    [SerializeField]
    private TagListType tagListType = TagListType.Blacklist;

    // A list of tags which we use to determine whether to explode or not
    // Depending on the tagListType (Blacklist or Whitelist)
    [SerializeField]
    private List<string> tags;

    // for trigger events
    void OnTriggerEnter2D(Collider2D other)
    {
        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist && tagInList)
        {
            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            ProcessCollision(other.gameObject);
        }
        else if (tagListType == TagListType.Whitelist && !tagInList)
        {
            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            ProcessCollision(other.gameObject);
        }
    }

    // for collision events
    void OnCollisionEnter2D(Collision2D other) 
    {
        bool tagInList = tags.Contains(other.gameObject.tag);

        if (tagListType == TagListType.Blacklist && tagInList) 
        {
            // Destroy if it's a Blacklist and the tag IS in the Blacklist
            ProcessCollision(other.gameObject);
        } 
        else if (tagListType == TagListType.Whitelist && !tagInList) 
        {
            // Destroy if it's a Whitelist and the tag is NOT in the Whitelist
            ProcessCollision(other.gameObject);
        }
    }

    // state when a game object collided with something
    protected virtual void ProcessCollision(GameObject other) 
    {
        print("Detected collision with " + other.name);
    }
}

// types of collisions that are available
public enum TagListType 
{
    Blacklist,
    Whitelist
}

