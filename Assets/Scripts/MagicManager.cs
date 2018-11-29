using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour {

    public GameObject rune1;
    public GameObject rune2;
    public GameObject rune3;
    public GameObject rune4;
    public GameObject rune5;
    public GameObject rune6;
    public GameObject rune7;
    public GameObject rune8;
    public GameObject rune9;
    public GameObject rune10;
    public GameObject rune11;
    public GameObject rune12;

    public GameObject character;
    public Wand wand;

    public GameObject FireBallIcon;
    public GameObject FrostIcon;
    public GameObject LightningIcon;
    public GameObject TeleportIcon;



    public GameObject IconEffect;

    public Canvas UIOverlay;
    public GameObject StoredFireballIcon;
    public GameObject StoredFrostIcon;
    public GameObject StoredLightningIcon;
    public GameObject StoredTeleportIcon;

    public GameObject[] UISkillBox;



    //public GameObject Icon;

    ArrayList runes = new ArrayList();
    ArrayList triggered = new ArrayList();
    string[] storedSpell = new string[4];
    GameObject[] storedSpellIcon = new GameObject[4];

    // Use this for initialization
    void Start () {
        runes.Add(rune1);
        runes.Add(rune2);
        runes.Add(rune3);
        runes.Add(rune4);
        runes.Add(rune5);
        runes.Add(rune6);
        runes.Add(rune7);
        runes.Add(rune8);
        runes.Add(rune9);
        runes.Add(rune10);
        runes.Add(rune11);
        runes.Add(rune12);
        character = GameObject.Find("Character");



    }
	
	// Update is called once per frame
    void Update () {
        foreach (GameObject rune in runes){
            MouseMovement mm = (MouseMovement)rune.GetComponent(typeof(MouseMovement));
            if (mm.HasEffect() && mm.mouseDown && !triggered.Contains(rune))
            {
                triggered.Add(rune);
            }
            else if (!mm.mouseDown){
                if (triggered.Count == 2 && triggered.Contains(rune1) && triggered.Contains(rune2)){
                    StoreSpell("FireBall");
                }

                if (triggered.Count == 2 && triggered.Contains(rune2) && triggered.Contains(rune3))
                {
                    StoreSpell("Frost");
                }

                if (triggered.Count == 3 && triggered.Contains(rune1) && triggered.Contains(rune2) && triggered.Contains(rune3))
                {
                    StoreSpell("Lightning");
                }
                if (triggered.Count == 3 && triggered.Contains(rune4) && triggered.Contains(rune2) && triggered.Contains(rune3))
                {
                    StoreSpell("Teleport");
                }
                triggered = new ArrayList();
            }
        }

        if (Input.GetButtonDown("Spell1")){
            if (storedSpell[0] != null){
                CastSpell(storedSpell[0]);
                storedSpell[0] = null;
                Destroy(storedSpellIcon[0]);
                storedSpellIcon[0] = null;
            }
        }
        if (Input.GetButtonDown("Spell2"))
        {
            if (storedSpell[1] != null)
            {
                CastSpell(storedSpell[1]);
                storedSpell[1] = null;
                Destroy(storedSpellIcon[1]);
                storedSpellIcon[1] = null;
            }
        }
        if (Input.GetButtonDown("Spell3"))
        {
            if (storedSpell[2] != null)
            {
                CastSpell(storedSpell[2]);
                storedSpell[2] = null;
                Destroy(storedSpellIcon[2]);
                storedSpellIcon[2] = null;
            }
        }
        if (Input.GetButtonDown("Spell4"))
        {
            if (storedSpell[3] != null)
            {
                CastSpell(storedSpell[3]);
                storedSpell[3] = null;
                Destroy(storedSpellIcon[3]);
                storedSpellIcon[3] = null;
            }
        }

    }

    public void CastSpell(string spell){
        if (spell.Equals("FireBall")){
            Debug.Log("fireball casted");
            wand.FireBall();
        }
        if (spell.Equals("Frost")){
            wand.Frost();
        }
        if (spell.Equals("Lightning")){
            wand.Lightning();
        }
        if (spell.Equals("Teleport"))
        {
            Debug.Log("Entered");
            wand.Teleport();
        }
    }

    public void StoreSpell(string spell){
        for (int i = 0; i < 4; i++){
            if (storedSpell[i] == null){
                storedSpell[i] = spell;
                SpellIconAnim(spell);
                StoreSpellIcon(spell, i);
                break;
            }
        }
    }

    public void StoreSpellIcon(string spell, int position){

        //GameObject icon = null;

        if (spell.Equals("FireBall"))
        {
            storedSpellIcon[position] = Instantiate(StoredFireballIcon, UIOverlay.transform.position, UIOverlay.transform.rotation);
            //storedSpellIcon[position].transform.SetParent(UIOverlay.transform);
            //storedSpellIcon[position].transform.position += new Vector3(596 + position * 70, -347, 0);
        }
        if (spell.Equals("Frost"))
        {
            storedSpellIcon[position] = Instantiate(StoredFrostIcon, UIOverlay.transform.position, UIOverlay.transform.rotation);
            //storedSpellIcon[position].transform.SetParent(UIOverlay.transform);
            //storedSpellIcon[position].transform.position += new Vector3(596 + position * 70, -347, 0);
        }
        if (spell.Equals("Lightning"))
        {
            storedSpellIcon[position] = Instantiate(StoredLightningIcon, UIOverlay.transform.position, UIOverlay.transform.rotation);
            //storedSpellIcon[position].transform.SetParent(UIOverlay.transform);
            //storedSpellIcon[position].transform.position += new Vector3(596 + position * 70, -347, 0);
        }
        if (spell.Equals("Teleport"))
        {
            storedSpellIcon[position] = Instantiate(StoredTeleportIcon, UIOverlay.transform.position, UIOverlay.transform.rotation);
            //storedSpellIcon[position].transform.SetParent(UIOverlay.transform);
            //storedSpellIcon[position].transform.position += new Vector3(596 + position * 70, -347, 0);
        }

        // Moved copy pasted shit down here
        storedSpellIcon[position].transform.SetParent(UIOverlay.transform,false);
        storedSpellIcon[position].transform.position = UISkillBox[position].transform.position;

    }

    public void SpellIconAnim(string spell)
    {
        if (spell.Equals("FireBall"))
        {
            Instantiate(IconEffect, transform.position, transform.rotation);
            Animation anim = FireBallIcon.GetComponent<Animation>();
            anim.Play("Icon Respown");
        }
        if (spell.Equals("Frost"))
        {
            Instantiate(IconEffect, transform.position, transform.rotation);
            Animation anim = FrostIcon.GetComponent<Animation>();
            anim.Play("Icon Respown");
        }
        if (spell.Equals("Lightning"))
        {
            Instantiate(IconEffect, transform.position, transform.rotation);
            Animation anim = LightningIcon.GetComponent<Animation>();
            anim.Play("Icon Respown");
        }
        if (spell.Equals("Teleport"))
        {
            Instantiate(IconEffect, transform.position, transform.rotation);
            Animation anim = TeleportIcon.GetComponent<Animation>();
            anim.Play("Icon Respown");
        }
    }
}
