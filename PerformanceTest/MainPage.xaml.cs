﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsRuntimeComponent1;
using WindowsRuntimeComponent2;

namespace PerformanceTest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private ObservableCollection<string> Console { get; } = new ObservableCollection<string>();

        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            Test1();
            Test2();
        }

        private async void Test1()
        {
            Console.Add("Instantiating 10000 C++/CX objects from C#");
            var stopWatch = new Stopwatch();
            await Task.Run(() =>
            {
                stopWatch.Start();

                var list = new List<Class1>();
                for (int i = 0; i < 100000; i++)
                    list.Add(new Class1());

                stopWatch.Stop();
            });
            Console.Add($"Done in {stopWatch.Elapsed}");
        }

        private async void Test2()
        {
            Console.Add("Instantiating 10000 C++/CX objects from C++/CX WRC");

            var stopWatch = new Stopwatch();

            await Task.Run(() =>
            {
                stopWatch.Start();
                var list = new List<Class1>();
                for (int i = 0; i < 100000; i++)
                    list.Add(Factory.CreateObject());
                stopWatch.Stop();
            });

            Console.Add($"Done in {stopWatch.Elapsed}");
        }
    }
}