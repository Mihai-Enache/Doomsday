using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : ManaUser, IPunObservable
{
    PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();

        photonView.ObservedComponents.Add(this);
        if (!photonView.IsMine)
        {
            //enabled = false;
        }
    }
    public float xpDropped = 0;
    /// <summary>Used for mob item and gold drops.</summary>
    public Inventory inventory;
    public List<string> spellNames = new List<string>();
    public Unit target;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        alliance = Alliance.Evil;
        int i = 0;
        foreach (string spellName in spellNames)
        {
            SetSpell(i++, spellName);
        }
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();
        if (target != null)
            for (int i = 0; i < spellNames.Count; ++i)
                CastSpell(i, target.transform.position);
    }

    public override void Die()
    {
        foreach (Hero h in FindObjectsOfType<Hero>())
        {
            h.AddExperience(xpDropped);
        }
        base.Die();
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            // We own this player: send the others our data
            stream.SendNext(transform.position); //position of the character
            stream.SendNext(transform.rotation); //rotation of the character
            stream.SendNext(gameObject.GetComponent<Monster>().health);

        }
        else
        {
            // Network player, receive data
            Vector3 syncPosition = (Vector3)stream.ReceiveNext();
            Quaternion syncRotation = (Quaternion)stream.ReceiveNext();
            gameObject.GetComponent<Monster>().health = (float)stream.ReceiveNext();
        }
    }
}
