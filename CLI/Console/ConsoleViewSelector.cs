﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CLI.Controller;
using CLI.Model;

namespace CLI.Console;

public class ConsoleViewSelector
{
    private Controller.Controller _controller;
    private ConsoleViewDepartment consoleDepartment;
    private ConsoleViewGrade consoleGrade;
    private ConsoleViewStudent consoleStudent;
    private ConsoleViewSubject consoleSubject;
    private ConsoleViewProfessor consoleProfessor;

    public ConsoleViewSelector()
    {
        _controller = new Controller.Controller();
        consoleDepartment = new ConsoleViewDepartment(_controller);
        consoleGrade = new ConsoleViewGrade(_controller);
        consoleStudent = new ConsoleViewStudent(_controller);
        consoleSubject = new ConsoleViewSubject(_controller);
        consoleProfessor = new ConsoleViewProfessor(_controller);
    }

    public void RunSelector()
    {
        while (true)
        {
            ShowSelector();
            System.Console.Write("\nInput: ");
            string userInput = System.Console.ReadLine() ?? "0";
            ConsoleViewUtils.ConsoleRefresh();
            if (userInput == "0")
            {
                _controller.SaveAllToStorage();
                break;
            }
            HandleSelector(userInput);
        }
    }

    private void ShowSelector()
    {
        ShowLogo();
        System.Console.WriteLine("\nChoose an option: ");
        System.Console.WriteLine("  1: Departments");
        System.Console.WriteLine("  2: Professors");
        System.Console.WriteLine("  3: Subjects");
        System.Console.WriteLine("  4: Students");
        System.Console.WriteLine("  5: Grades");
        System.Console.WriteLine("  0: Close");
    }

    private void HandleSelector(string input)
    {
        switch (input)
        {
            case "1":
                consoleDepartment.RunMenu();
                break;
            case "2":
                consoleProfessor.RunMenu();
                break;
            case "3":
                consoleSubject.RunMenu();
                break;
            case "4":
                consoleStudent.RunMenu();
                break;
            case "5":
                consoleGrade.RunMenu();
                break;
        }
    }

    private void ShowLogo()
    {
        string logo =
            "  _____ _             _            _          _____                 _               \r\n / ____| |           | |          | |        / ____|               (_)              \r\n| (___ | |_ _   _  __| | ___ _ __ | |_ _____| (___   ___ _ ____   ___  ___ ___  ___ \r\n \\___ \\| __| | | |/ _` |/ _ \\ '_ \\| __|______\\___ \\ / _ \\ '__\\ \\ / / |/ __/ _ \\/ __|\r\n ____) | |_| |_| | (_| |  __/ | | | |_       ____) |  __/ |   \\ V /| | (_|  __/\\__ \\\r\n|_____/ \\__|\\__,_|\\__,_|\\___|_| |_|\\__|     |_____/ \\___|_|    \\_/ |_|\\___\\___||___/";
        ConsoleViewUtils.ConsoleWriteLineColor(logo, ConsoleColor.Cyan);
    }
}
