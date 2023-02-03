using System;
using System.Diagnostics;

class Program {
  
  static void KillByName(string x, System.Diagnostics.Process[] task){
  x.ToLower();
  for (int i=0;i < task.Length;++i){
    if (task[i].ProcessName.ToLower() == x){
      Console.WriteLine($"Процесс {task[i].ProcessName} завершён");
      task[i].Kill();
    }
  }
}

static void KillById(int x, System.Diagnostics.Process[] task){
  for (int i=0;i < task.Length;++i){
    if (task[i].Id == x){
      Console.WriteLine($"Процесс {task[i].ProcessName} завершён");
      task[i].Kill();
    }
  }
}

//static void Search(String x, System.Diagnostics.Process[] task){
//  for (int i=0;i < task.Length;++i){
//    if (task[i].ProcessName.ToLower().IndexOf(x){
//      Console.WriteLine($"{task[i].ProcessName, -40} {task[i].Id}");}
//      breck;}
//}

static void Print(System.Diagnostics.Process[] task){
  for (int i=0;i < task.Length;++i){
    Console.WriteLine($"{task[i].ProcessName, -40} {task[i].Id}");}
  }

static void Help(){
  Console.WriteLine("Print - print all process");
  Console.WriteLine("KillById <id> - kill process by id");
  Console.WriteLine("KillByName <name> - kill process by it's name");
  Console.WriteLine("Search <part of name> - find process by it's name part");
  Console.WriteLine("Exit - stop the programm");  
}
  
static void Main(string[] args) {
  var tasks = Process.GetProcesses();
  for (int i=0;i < tasks.Length;++i){
    Console.WriteLine($"{tasks[i].ProcessName, -40} {tasks[i].Id}");}
  string command;
  while (true){
    Console.Write("command << ");
    command = Console.ReadLine().ToLower();
    if (command == "help"){
      Help();
    }
    else if (command == "print"){
      Print(tasks);
    }
    else if (command.StartsWith("killbyid")){
      KillById(Convert.ToInt32(command.Split()[1]), tasks);
    }
    else if (command.StartsWith("killbyname")){
      KillById(command.Split(" ")[1], tasks);
    }
    //else if (command.StartsWith("search")){
    //  KillById(command.Split(" ")[1], tasks);
    //}
    else {
       Console.Write("ERROR");
    }
    }
  }
}
