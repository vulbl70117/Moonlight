using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject _explosion_particle;///
    public ParticleSystem partic;///
    public MeshRenderer mesh;
    public Machine_Attack _Machine_Attack;///
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Machine"))
            return;
        if (other.CompareTag("Weapon"))
        {
            Weapon_Collision _Weapon_Collision = other.gameObject.GetComponent<Weapon_Collision>();
            gameObject.GetComponent<Collider>().enabled = false;
            mesh.enabled = false;
            partic.Stop();///
            ins_explosion();///
            _Weapon_Collision.Weapon._Player._Renderer._AudioSource.PlayOneShot(_Weapon_Collision.Weapon._Player._Renderer._AudioClip[0]);//爆炸音效   
            Destroy(gameObject, 3);///
        }
        if (other.CompareTag("Player"))
        {
            Player _Player = other.gameObject.GetComponent<Player>();
            if (_Player._Move._EvadeBool_01 == false)
            {
                ins_explosion();///
                _Player._Renderer.BeAttack();
                mesh.enabled = false;
                partic.Stop();///
                Destroy(gameObject, 3);

                _Player._Renderer._IsMachine_atk = false;
                _Player._Renderer._AudioSource.PlayOneShot(_Player._Renderer._AudioClip[0]);//爆炸音效                
            }
        }
    }
    public void ins_explosion()//生成爆炸
    {
        GameObject eff = Instantiate(_explosion_particle);///
        if (_explosion_particle)///
        {
            eff.transform.position = transform.position;
            eff.transform.rotation = transform.rotation;
            Destroy(eff, 2);
        }///
    }
}
