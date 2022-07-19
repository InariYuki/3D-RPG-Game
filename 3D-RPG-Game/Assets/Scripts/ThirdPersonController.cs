using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KitsuneYuki
{
    /// <summary>
    /// 移動、跳躍與動畫控制
    /// </summary>
    public class ThirdPersonController : MonoBehaviour
    {
        #region 資料
        [SerializeField, Range(0, 50)] float run_speed = 5f;
        [SerializeField, Range(0, 50)] float turn_speed = 5f;
        [SerializeField, Range(0, 50)] float jump_height = 7f;
        Animator anim_ctl;
        CharacterController char_ctl;
        Vector3 direction;
        Transform camera_transform;
        string move_parameter = "float_move";
        string jump_parameter = "trigger_jump";
        #endregion
        #region 事件
        private void Awake()
        {
            anim_ctl = GetComponent<Animator>();
            char_ctl = GetComponent<CharacterController>();
            camera_transform = GameObject.Find("Main Camera").transform;
        }
        private void Update()
        {
            move();
            jump();
        }
        #endregion
        #region 方法
        /// <summary>
        /// 移動
        /// </summary>
        private void move()
        {
            //movement & rotation
            float vertical_axis_value = Input.GetAxisRaw("Vertical");
            float horizontal_axis_value = Input.GetAxisRaw("Horizontal");
            direction.z = vertical_axis_value;
            direction.x = horizontal_axis_value;
            direction = transform.TransformDirection(direction);
            char_ctl.Move(direction * run_speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation , camera_transform.rotation , turn_speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0 , transform.eulerAngles.y , 0);
            //animation
            float v_axis = Input.GetAxis("Vertical");
            float h_axis = Input.GetAxis("Horizontal");
            if(Mathf.Abs(v_axis) > 0)
            {
                anim_ctl.SetFloat(move_parameter , Mathf.Abs(v_axis));
            }
            else if(Mathf.Abs(h_axis) > 0)
            {
                anim_ctl.SetFloat(move_parameter, Mathf.Abs(h_axis));
            }
            else
            {
                anim_ctl.SetFloat(move_parameter , 0);
            }
        }
        /// <summary>
        /// 跳躍
        /// </summary>
        private void jump()
        {
            if(char_ctl.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jump_height;
                anim_ctl.SetTrigger(jump_parameter);
            }
            direction.y += Physics.gravity.y * Time.deltaTime;
        }
        #endregion
    }
}
