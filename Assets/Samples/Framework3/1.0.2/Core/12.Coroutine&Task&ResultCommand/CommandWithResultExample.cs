namespace Framework3.Core.Example._12.Coroutine_Task_ResultCommand
{
    using System;
    using System.Collections;
    using System.Threading.Tasks;
    using UnityEngine;

    public class CommandWithResultExample : MonoBehaviour
    {
        public class ExampleArchitecture : AbstractArchitecture<ExampleArchitecture>
        {
            protected override void Init() { }
        }

        public class SimpleResultCommand : AbstractCommand<string>
        {
            protected override string OnExecute()
            {
                return "Hello Command With Result";
            }
        }

        public class ACoroutineCommand : AbstractCommand<IEnumerator>
        {
            protected override IEnumerator OnExecute()
            {
                Debug.Log("A Coroutine Command Start:" + Time.time);
                yield return new WaitForSeconds(1.0f);
                Debug.Log("A Coroutine Command Finish:" + Time.time);
            }
        }

        public class TaskACommand : AbstractCommand<Task<bool>>
        {
            protected override async Task<bool> OnExecute()
            {
                await Task.Delay(TimeSpan.FromSeconds(2f));
                return true;
            }
        }

        void Start()
        {
            Debug.Log(ExampleArchitecture.Architecture.SendCommand(new SimpleResultCommand()));
            StartCoroutine(ExampleArchitecture.Architecture.SendCommand(new ACoroutineCommand()));
            SendTaskACommand();
        }

        async void SendTaskACommand()
        {
            var result = await ExampleArchitecture.Architecture.SendCommand(new TaskACommand());
            Debug.Log("A Task Command Result: " + result + ", time: " + Time.time); // 输出 1.5f，因为异步时间与 Time.time 不严格同步
        }
    }
}