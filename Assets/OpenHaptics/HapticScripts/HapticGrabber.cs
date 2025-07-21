using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HapticPlugin;


// 通过碰撞检测以及抓取参数，设置虚拟力杆与碰撞物体间的关节连接，实现抓取效果；
// 并通过设置HapticPlugin中的物理操作效果变量（bool），实现虚拟力杆对虚拟物体的物理作用；
public class HapticGrabber : MonoBehaviour
{
    #region public_value
    /// <summary>
    /// 抓取按键编号(默认为0)
    /// </summary>
    public int buttonID = 0;
    /// <summary>
    /// 使用按钮作为抓取开关(默认关闭；关闭则是按下按钮时抓取）
    /// </summary>
    public bool ButtonActsAsToggle = false;
    public enum PhysicsToggleStyle { none, onTouch, onGrab };
    /// <summary>
    /// 设置物理切换样式
    /// Should the grabber script toggle the physics forces on the stylus? 
    /// </summary>
    public PhysicsToggleStyle physicsToggleStyle = PhysicsToggleStyle.none;
    /// <summary>
    /// 是否禁用与可触摸对象的Unity碰撞
    /// </summary>
    public bool DisableUnityCollisionsWithTouchableObjects = true;
    #endregion


    #region private_value
    /// <summary>
    /// Reference to the GameObject representing the Haptic Device
    /// </summary>
    private GameObject hapticDevice = null;
    /// <summary>
    ///  Is the button currently pressed?
    /// </summary>
    private bool buttonStatus = false;
    /// <summary>
    /// Reference to the object currently touched
    /// </summary>
    private GameObject touching = null;
    /// <summary>
    /// Reference to the object currently grabbed
    /// </summary>
    private GameObject grabbing = null;
    /// <summary>
    /// The Unity physics joint created between the stylus and the object being grabbed.
    /// </summary>
    private FixedJoint joint = null;
    #endregion


    /// <summary>
    /// 初始化，获得HapticPlugin，检查控制位状态
    /// </summary>
    void Start()
    {
        // 获得场景中的HapticPlugin
        if (hapticDevice == null)
        {
            HapticPlugin[] HPs = (HapticPlugin[])Object.FindObjectsOfType(typeof(HapticPlugin));
            foreach (HapticPlugin HP in HPs)
            {
                if (HP.hapticManipulator == this.gameObject)
                {
                    hapticDevice = HP.gameObject;
                }
            }
        }

        // 是否禁用物理力的影响
        if (physicsToggleStyle != PhysicsToggleStyle.none)
            hapticDevice.GetComponent<HapticPlugin>().PhysicsManipulationEnabled = false;

        // 是否禁用与标记为 "Touchable" 的其他对象的 Unity 碰撞
        if (DisableUnityCollisionsWithTouchableObjects)
            disableUnityCollisions();
    }


    /// <summary>
    /// 忽略与所有标签为“Touchable”的物体的碰撞检测
    /// </summary>
    void disableUnityCollisions()
    {
        GameObject[] touchableObjects;
        touchableObjects = GameObject.FindGameObjectsWithTag("Touchable") as GameObject[];

        // Ignore my collider
        // 忽略与所有标签为“touchable”的物体的碰撞
        Collider myC = gameObject.GetComponent<Collider>();
        if (myC != null)
            foreach (GameObject T in touchableObjects)
            {
                Collider CT = T.GetComponent<Collider>();
                if (CT != null)
                    Physics.IgnoreCollision(myC, CT);
            }

        // Ignore colliders in children.
        // 忽略与所有标签为“touchable”的子物体的碰撞
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider C in colliders)
            foreach (GameObject T in touchableObjects)
            {
                Collider CT = T.GetComponent<Collider>();
                if (CT != null)
                    Physics.IgnoreCollision(C, CT);
            }
    }


    /// <summary>
    /// 处理抓取按钮逻辑，调用抓取与释放函数
    /// </summary>
    void FixedUpdate()
    {
        bool newButtonStatus = hapticDevice.GetComponent<HapticPlugin>().Buttons[buttonID] == 1;
        bool oldButtonStatus = buttonStatus;
        buttonStatus = newButtonStatus;

        // 如果按键状态从松开->按下
        if (oldButtonStatus == false && newButtonStatus == true)
        {
            // 如果使用按钮作为触发开关
            if (ButtonActsAsToggle)
            {
                // 如果当前状态为抓取，则释放；反之，则抓取；
                if (grabbing)
                    release();
                else
                    grab();
            }
            else
            {
                grab();
            }
        }
        // 如果按键状态从按下->松开
        if (oldButtonStatus == true && newButtonStatus == false)
        {
            if (ButtonActsAsToggle)
            {
                //Do Nothing
            }
            else
            {
                release();
            }
        }

        // TODO: 开启物理效果究竟是为了什么？
        // Make sure haptics is ON if we're grabbing
        if (grabbing && physicsToggleStyle != PhysicsToggleStyle.none)
            hapticDevice.GetComponent<HapticPlugin>().PhysicsManipulationEnabled = true;
        if (!grabbing && physicsToggleStyle == PhysicsToggleStyle.onGrab)
            hapticDevice.GetComponent<HapticPlugin>().PhysicsManipulationEnabled = false;
    }


    /// <summary>
    /// 根据不同的物理交互模式（physicsToggleStyle）和触碰状态（isTouch）来动态控制虚拟力杆的物理效果
    /// </summary>
    /// <param name="isTouch"></param>
    private void hapticTouchEvent(bool isTouch)
    {
        // 1. 如果设置抓取时触发物理效果
        if (physicsToggleStyle == PhysicsToggleStyle.onGrab)
        {
            if (isTouch)  // 如果正在开始触碰，则打开物理效果
                hapticDevice.GetComponent<HapticPlugin>().PhysicsManipulationEnabled = true;
            else
                return;   // 直接返回，不释放触觉效果（避免在持有物体时意外释放）
        }

        // 2. 如果设置触碰时触发物理效果
        if (physicsToggleStyle == PhysicsToggleStyle.onTouch)
        {
            // 如果正在接触，则开启物理效果，进行物理交互
            hapticDevice.GetComponent<HapticPlugin>().PhysicsManipulationEnabled = isTouch;

            // 将虚拟物体的速度和角速度都设置为零，即停止物体的运动
            GetComponentInParent<Rigidbody>().linearVelocity = Vector3.zero;
            GetComponentInParent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }


    /// <summary>
    /// 在虚拟力杆与其他物体发生碰撞时，获取碰撞物体信息，根据条件设置 touching 变量，表示当前触碰物体
    /// </summary>
    /// <param name="collisionInfo"></param>
    void OnCollisionEnter(Collision collisionInfo)
    {
        // 1. 获得与虚拟力杆碰撞的物体的碰撞器
        Collider other = collisionInfo.collider;
        // 2. 获得碰撞物体的 GameObject
        GameObject that = other.gameObject;
        // 3. 获取碰撞物体上的 Rigidbody 组件
        Rigidbody thatBody = that.GetComponent<Rigidbody>();

        // 4. 循环向上遍历其父对象，直到找到包含 Rigidbody 的物体，或者没有父对象为止
        while (thatBody == null)
        {
            if (that.transform == null || that.transform.parent == null)
                break;
            GameObject parent = that.transform.parent.gameObject;
            if (parent == null)
                break;
            that = parent;
            thatBody = that.GetComponent<Rigidbody>();
        }

        // 5. 如果碰撞信息中包含一个 Rigidbody, 调用产生触碰事件
        if (collisionInfo.rigidbody != null)
            hapticTouchEvent(true);

        if (thatBody == null)
            return;

        // 6. Kinematic 类型的 Rigidbody 是由动画或脚本控制的，不受物理引擎的力的作用, 因而直接返回
        if (thatBody.isKinematic)
            return;

        // 7. 将 touching 设置为当前与虚拟力杆碰撞的物体
        touching = that;
    }


    /// <summary>
    /// 在虚拟力杆与其他物体的碰撞结束时，根据条件设置 touching 变量，表示当前触碰的物体已经不再被虚拟力杆碰撞
    /// </summary>
    /// <param name="collisionInfo"></param>
    void OnCollisionExit(Collision collisionInfo)
    {
        // 获取与虚拟力杆碰撞的物体的碰撞器
        Collider other = collisionInfo.collider;

        // 如果碰撞信息中包含一个 Rigidbody, 则结束虚拟力杆与物体的触碰
        if (collisionInfo.rigidbody != null)
            hapticTouchEvent(false);

        // 如果 touching 为空，直接返回，不做后续处理
        if (touching == null)
            return;

        // 检查碰撞对象的有效性, 如果无效则返回
        if (other == null ||
            other.gameObject == null || other.gameObject.transform == null)
            return; // Other has no transform? Then we couldn't have grabbed it.

        // 检查触碰对象关系: 检查 touching 是否与当前碰撞的物体 other 相同，或为其子对象。
        // 如果是，则将 touching 设置为 null，表示虚拟力杆不再与任何物体发生碰撞
        if (touching == other.gameObject || other.gameObject.transform.IsChildOf(touching.transform))
        {
            touching = null;
        }
    }


    /// <summary>
    /// 在虚拟力杆与其他物体碰撞并按下抓取按钮时，将虚拟力杆与待抓取的物体连接起来，实现抓取效果
    /// （关键在于创建与虚拟力杆接触的物体间的joint连接）
    /// </summary>
    void grab()
    {
        // 1. 获取待抓取的物体
        // 首先尝试使用 touching 变量，该变量表示当前触碰到的物体
        GameObject touchedObject = touching;
        // 如果 touching 为空，说明没有通过 Unity 碰撞检测找到碰撞物体
        if (touchedObject == null)
        {
            // Maybe there's a Haptic Collision
            // 尝试通过虚拟力杆的 HapticPlugin 组件获取当前触碰到的物体
            touchedObject = hapticDevice.GetComponent<HapticPlugin>().touching;
        }

        // 2. 检查是否已经在抓取
        // 如果已经在抓取状态，则直接返回，不执行后续抓取逻辑
        if (grabbing != null)
            return;

        // 3. 检查待抓取物体的有效性
        // 如果没有待抓取的物体，直接返回
        if (touchedObject == null) // Nothing to grab
            return;

        // 4. 检查抓取的有效性
        // 如果待抓取的物体的标签是 "Gripper"，表示不能抓取 gripper 类型的物体，直接返回
        if (touchedObject.tag == "Gripper")
            return;

        // 5. 设置抓取物体
        // 将 touchedObject 设置为当前正在抓取的物体
        grabbing = touchedObject;

        // 6. 获取待抓取物体的 Rigidbody 组件
        Rigidbody body = grabbing.GetComponent<Rigidbody>();

        // 7. 检查 Rigidbody 的有效性, 并向上遍历直到获得有效的 RigidBody 或 没有父对象为止
        // If this doesn't have a rigidbody, walk up the tree. 
        // It may be PART of a larger physics object.
        while (body == null)
        {
            if (grabbing.transform.parent == null)
            {
                grabbing = null;
                return;
            }
            GameObject parent = grabbing.transform.parent.gameObject;
            if (parent == null)
            {
                grabbing = null;
                return;
            }
            grabbing = parent;
            body = grabbing.GetComponent<Rigidbody>();
        }

        // 8. 创建 FixedJoint 连接
        // 创建一个 FixedJoint 组件，并将其添加到虚拟力杆上
        // 将 FixedJoint 连接到待抓取物体的 Rigidbody 上，实现抓取效果
        joint = (FixedJoint)gameObject.AddComponent(typeof(FixedJoint));
        joint.connectedBody = body;
    }


    /// <summary>
    /// 用于递归设置物体及其所有子物体层级的静态方法
    /// （将输入的物体及其所有子物体的层级都设置为指定的层级 layerNumber）
    /// </summary>
    /// <param name="go"></param>
    /// <param name="layerNumber"></param>
    static void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            trans.gameObject.layer = layerNumber;
    }


    /// <summary>
    /// 完成释放被抓取对象的操作，包括解除关节连接、销毁关节组件，并根据物理切换样式的设置决定是否关闭物理操纵功能 
    /// </summary>
    void release()
    {
        // 1. 检查是否有需要释放的对象
        // 如果当前没有对象被抓取，则直接返回，无需执行后续释放操作
        if (grabbing == null)
            return;

        // 2. 断言确保关节存在
        // 确保在释放对象之前已经建立了关节连接
        Debug.Assert(joint != null);

        // 3. 释放关节连接, 解除与被抓取物体的连接
        joint.connectedBody = null;

        // 4. 销毁关节组件，释放关节的内存占用
        Destroy(joint);

        // 5. 重置抓取对象, 置为 null，表示当前没有对象被抓取
        grabbing = null;

        // 6. 根据物理切换样式，可能关闭物理操纵
        // 如果物理切换样式不是 none，表示物体与力操纵相关;
        // 将力操纵功能关闭，以停止对虚拟物体的物理操作
        if (physicsToggleStyle != PhysicsToggleStyle.none)
            hapticDevice.GetComponent<HapticPlugin>().PhysicsManipulationEnabled = false;
    }


    /// <summary>
    /// TODO: Returns true if there is a current object. 
    /// </summary>
    /// <returns></returns>
    public bool isGrabbing()
    {
        return (grabbing != null);
    }
}
