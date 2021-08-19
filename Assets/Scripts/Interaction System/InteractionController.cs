﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PointAndClick
{
    public class InteractionController : MonoBehaviour
    {
        public static InteractionController Instance { get; private set; } = null;
        public static IInventory Inventory { get { return Instance.inventory; } }

        private static Dictionary<int, bool> flags = new Dictionary<int, bool>();
        private static Dictionary<int, int> variables = new Dictionary<int, int>();

        [SerializeField]
        private IInventory inventory;


        private void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        public static void SetFlag(int id)
        {
            flags[id] = true;
        }
        public static void UnsetFlag(int id)
        {
            flags[id] = false;
        }
        public static void ToggleFlag(int id)
        {
            flags[id] = !flags[id];
        }
        public static bool GetFlag(int id)
        {
            if (!flags.ContainsKey(id))
                UnsetFlag(id);
            return flags[id];
        }

        public static void ChangeVariable(VariableSetting settings)
        {
            switch (settings.type)
            {
                case VariableSetting.Type.Set:
                    variables[settings.id] = settings.value;
                    break;
                case VariableSetting.Type.Add:
                    variables[settings.id] += settings.value;
                    break;
                case VariableSetting.Type.SetVariable:
                    variables[settings.id] = variables[settings.value];
                    break;
                case VariableSetting.Type.AddVariable:
                    variables[settings.id] += variables[settings.value];
                    break;
            }
        }

        public static bool CompareVariableWithValue(int varId, VariableSetting.CompareType compareType, int value)
        {
            switch (compareType)
            {
                case VariableSetting.CompareType.Less:
                    return variables[varId] < value;

                case VariableSetting.CompareType.NotLess:
                    return variables[varId] >= value;

                case VariableSetting.CompareType.Equal:
                    return variables[varId] == value;

                case VariableSetting.CompareType.NotEqual:
                    return variables[varId] != value;

                case VariableSetting.CompareType.Greater:
                    return variables[varId] > value;

                case VariableSetting.CompareType.NotGreater:
                    return variables[varId] <= value;
            }
            return false;
        }

        public static bool CompareVariables(int var1, VariableSetting.CompareType compareType, int var2)
        {
            switch (compareType)
            {
                case VariableSetting.CompareType.Less:
                    return variables[var1] < variables[var2];

                case VariableSetting.CompareType.NotLess:
                    return variables[var1] >= variables[var2];

                case VariableSetting.CompareType.Equal:
                    return variables[var1] == variables[var2];

                case VariableSetting.CompareType.NotEqual:
                    return variables[var1] != variables[var2];

                case VariableSetting.CompareType.Greater:
                    return variables[var1] > variables[var2];

                case VariableSetting.CompareType.NotGreater:
                    return variables[var1] <= variables[var2];
            }
            return false;
        }


        public void Print(object obj)
        {
            Debug.Log(obj);
        }



    }
}