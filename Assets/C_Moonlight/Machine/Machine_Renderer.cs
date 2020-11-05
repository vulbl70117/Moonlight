using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Machine_Animator
{
    Run,
    Attack,
    BeAttack,
    Attacking_move
}
public class Machine_Renderer : MonoBehaviour
{
    
    public float _Machine_HP = 3;
    public Animator _Machine_AM;
    //
    public bool _StrikeBool;
    //
    //
    private Player _Player;
    //
    public Machine _Machine;

    public List<AudioSource> BeAtk_AudioSources; //
    public GameObject _Effect_Atked;//
    public GameObject _Effect_Dead;//
    public Transform _Effect_Atked_here;//
    public float _BeAttack_time = 1;

    private Collider _MachineCollider;//
    public GameObject _Machine_mesh;//
    public GameObject _Machine_Deadmesh;//
    public Rigidbody[] rigidbodies;//
    private float explosionForce = 400f;  //爆炸力道
    private float explosionRadius = 3;     //爆炸半徑
    void Start()
    {
        _MachineCollider = GetComponent<Collider>();
        _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbodies = _Machine_Deadmesh.GetComponentsInChildren<Rigidbody>();//機器碎片
    }

    // Update is called once per frame
    void Update()
    {
        Machine_Anim(Machine_Animator.Run);
        //if (_MaterialBool)
        //    Machine_Material();
        if(_BeAttack_time>-10)
        {
              _BeAttack_time -= Time.time;
        }
    }
    public void BeAttack(float damge)
    {
        if (_StrikeBool)
            return;
        Debug.Log("Target BeAttack!!/  HP: " + _Machine_HP);

        int i = Random.Range(0, 2);///
        BeAtk_AudioSources[i].Play();///
        GameObject eff = Instantiate(_Effect_Atked);///
        if (_Effect_Atked)///
        {
            eff.transform.position = _Effect_Atked_here.transform.position;
            eff.transform.rotation = _Effect_Atked_here.transform.rotation;
            Destroy(eff, 1);
        }///
        _BeAttack_time = 1;

        if (_Machine_AM != null)
        {
            Machine_Anim(Machine_Animator.BeAttack);
            _Machine_HP -= damge;
            _StrikeBool = true;
            if (_Machine_HP <= 0)
            {
                if (_MachineCollider)
                    _MachineCollider.enabled = false;//關碰撞
                if (_Machine_mesh)
                    _Machine_mesh.SetActive(false);//關顯示
                if (_Machine_Deadmesh)
                    _Machine_Deadmesh.SetActive(true);
                _Machine_Deadmesh.transform.parent = null;
                Destroy(_Machine_Deadmesh, 5);
                for (int x = 0; x < rigidbodies.Length; x++)
                {
                    rigidbodies[x].AddExplosionForce(explosionForce, transform.position, explosionRadius);//給碎掉的機器施加爆炸的力
                }
                BeAtk_AudioSources[3].Play();//死亡音效
                GameObject eff_dead = Instantiate(_Effect_Dead);///
                if (_Effect_Dead)///
                {
                    eff_dead.transform.position = gameObject.transform.position;
                    eff_dead.transform.rotation = gameObject.transform.rotation;
                    Destroy(eff_dead, 3);
                }///
                _Player._Trigger._Evade_ToMachine = false;
                Destroy(gameObject, 5);
            }
        }
    }
    public void Machine_Anim(Machine_Animator _Animator, bool isTrue = false)
    {
        if (_Machine_AM == null)
            return;
        switch (_Animator)
        {
            case Machine_Animator.Run:
                {
                    if (_Machine._Move._MoveAnim)
                    {
                        _Machine_AM.SetBool("Run", true);
                    }
                    else if (_Machine._Move._MoveAnim == false)
                    {
                        _Machine_AM.SetBool("Run", false);
                    }
                    break;
                }
            case Machine_Animator.Attack:
                {
                    _Machine_AM.SetBool("Attack",true);
                    break;
                }
            case Machine_Animator.BeAttack:
                {
                    _Machine_AM.SetTrigger("BeAttack");
                    break;
                }
            case Machine_Animator.Attacking_move:///
                {
                    _Machine_AM.SetTrigger("Attacking");
                    break;
                }///
        }
    }
}
