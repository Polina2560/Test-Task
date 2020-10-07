using System;
using System.Collections.Generic;

namespace ds.test.impl
{
    public class PluginNotFoundException : ApplicationException
    {
        public PluginNotFoundException() { }
        public PluginNotFoundException(string message) : base(message) { }
    }

    public interface IPlugin
    {
        string PluginName { get; }      // Навание плагина
        string Version { get; }         // Версия
        System.Drawing.Image Image { get; } // Изображение 
        string Description { get; }         // Описание
        int Run(int input1, int input2);    // Реализация некоторых арифметических операций
    }

    abstract class ProgramAddition : IPlugin
    {
        public string PluginName { get; }
        public string Version { get; }
        public System.Drawing.Image Image { get; }
        public string Description { get; }

        public int Run(int input1, int input2)
        {
            while (true)
            {
                Console.WriteLine("Choose math function:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Difference (subtraction)");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division (integer only)");
                int mathFunc = Convert.ToInt32(Console.ReadLine());     // Выбор математической операции
                switch (mathFunc)
                {
                    case 1:
                        return input1 + input2;
                    case 2:
                        return Math.Max(Math.Abs(input1), Math.Abs(input2)) - Math.Min(Math.Abs(input1), Math.Abs(input2));
                    case 3:
                        return input1 * input2;
                    case 4:
                        return Math.Max(Math.Abs(input1), Math.Abs(input2)) / Math.Min(Math.Abs(input1), Math.Abs(input2));
                    default:
                        Console.WriteLine("Wrong Input. Try again.");
                        break;

                }
            }
        }
    }

    public static class Plugins
    {
        static int PluginsCount { get; }        // Количество плагинов
        static string[] GetPluginNames { get; }     // Массив имён плагинов

        static Dictionary<string, IPlugin> PluginsDictionary = new Dictionary<string, IPlugin>();   // Словать всех плагинов

        // Получение конкретного плагина по имени
        static IPlugin GetPlugin(string pluginName)
        {
            IPlugin plugin;
            if (PluginsDictionary.TryGetValue(pluginName, out plugin))
            {
                return plugin;
            }
            else
            {
                throw new PluginNotFoundException("Plugin with name \'" + pluginName + "\' - not found");
            }
        }
    }
}
