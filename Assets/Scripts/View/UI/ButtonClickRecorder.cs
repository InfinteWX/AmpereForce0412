using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickRecorder : MonoBehaviour
{
    private bool isExperimentRunning = false;
    private Dictionary<string, int> clickCounts = new Dictionary<string, int>();

    // UI引用（需在Inspector绑定）
    public Button btnStart;
    public Button btnEnd;
    public Text statusText;
    public List<Button> funcButtons;

    private void Start()
    {
        // 绑定开始/结束按钮事件
        btnStart.onClick.AddListener(StartExperiment);
        btnEnd.onClick.AddListener(EndExperiment);

        // 初始化功能按钮计数
        foreach (var btn in funcButtons)
        {
            // 确保每个按钮只添加一次（避免重复绑定）
            if (!clickCounts.ContainsKey(btn.name))
            {
                clickCounts[btn.name] = 0;
                btn.onClick.AddListener(() => OnFuncButtonClicked(btn.name));
            }
        }

        // 初始状态设置
        btnEnd.interactable = false;
        UpdateStatusText("实验未开始");
    }

    // 开始实验：重置计数（修正遍历方式）
    private void StartExperiment()
    {
        isExperimentRunning = true;

        // 关键修正：用临时列表存储键，避免遍历字典时触发异常
        List<string> buttonNames = new List<string>(clickCounts.Keys);
        foreach (var btnName in buttonNames)
        {
            clickCounts[btnName] = 0; // 安全重置值
        }

        // 更新UI状态
        btnStart.interactable = false;
        btnEnd.interactable = true;
        UpdateStatusText("实验进行中...");
        Debug.Log("实验开始，开始统计按钮点击");
    }

    // 结束实验并导出CSV
    private void EndExperiment()
    {
        if (!isExperimentRunning) return;

        isExperimentRunning = false;
        ExportToCSV();
        btnStart.interactable = true;
        btnEnd.interactable = false;
        UpdateStatusText("实验已结束，结果已导出");
        Debug.Log("实验结束，停止统计");
    }

    // 功能按钮点击计数（仅在实验中生效）
    private void OnFuncButtonClicked(string buttonName)
    {
        if (isExperimentRunning && clickCounts.ContainsKey(buttonName))
        {
            clickCounts[buttonName]++;
            Debug.Log($"[{buttonName}] 点击次数：{clickCounts[buttonName]}");
        }
    }

    // 更新状态文本
    private void UpdateStatusText(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;
        }
    }

    // 导出CSV文件
    private void ExportToCSV()
    {
        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"ButtonClickResult_{timestamp}.csv";
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("按钮名称,点击次数");
                foreach (var kvp in clickCounts)
                {
                    sw.WriteLine($"{kvp.Key},{kvp.Value}");
                }
            }
            Debug.Log($"CSV文件已保存至：{path}");
        }
        catch (Exception e)
        {
            Debug.LogError("导出CSV失败：" + e.Message);
        }
    }
}