// ------------------------------------------------------------
// @file       TableExample.cs
// @brief
// @author     zheliku
// @Modified   2024-11-01 14:11:43
// @Copyright  Copyright (c) 2024, zheliku
// ------------------------------------------------------------

namespace Framework.Toolkits.TableKit.Example
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sirenix.OdinInspector;
    using UnityEngine;

    public class TableExample : MonoBehaviour
    {
        [ShowInInspector]
        private School _school = new School();

        private void Start()
        {
            _school.Add(new Student() { Age = 1, Level = 2, Name = "liangxie" });
            _school.Add(new Student() { Age = 2, Level = 2, Name = "ava" });
            _school.Add(new Student() { Age = 3, Level = 2, Name = "abc" });
            _school.Add(new Student() { Age = 3, Level = 3, Name = "efg" });
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Log Level 2", GUILayout.Width(120), GUILayout.Height(50)))
            {
                foreach (var student in _school.LevelIndex.Get(2).Where(s => s.Age < 3))
                {
                    Debug.Log(student);
                }
            }

            GUILayout.Space(20);
            
            GUILayout.EndHorizontal();
        }
    }

    public class School : Table<Student>
    {
        [ShowInInspector]
        public TableIndex<int, Student> AgeIndex = new TableIndex<int, Student>(
            student => student.Age
        );

        [ShowInInspector]
        public TableIndex<int, Student> LevelIndex = new TableIndex<int, Student>(
            student => student.Level
        );

        protected override void OnAdd(Student data)
        {
            AgeIndex.Add(data);
            LevelIndex.Add(data);
        }

        protected override void OnRemove(Student data)
        {
            AgeIndex.Remove(data);
            LevelIndex.Remove(data);
        }

        protected override void OnClear()
        {
            AgeIndex.Clear();
            LevelIndex.Clear();
        }

        protected override void OnDispose()
        {
            AgeIndex.Dispose();
            LevelIndex.Dispose();
        }

        public override IEnumerator<Student> GetEnumerator()
        {
            return AgeIndex.Dictionary.Values.SelectMany(student => student).GetEnumerator();
        }
    }

    [Serializable]
    public class Student
    {
        public string Name;

        public int Age;

        public int Level;

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Level: {Level}";
        }
    }
}