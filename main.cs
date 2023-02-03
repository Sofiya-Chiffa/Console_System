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

static void Search(String x, System.Diagnostics.Process[] task){
  for (int i=0;i < task.Length;++i){
    if (task[i].ProcessName.ToLower().IndexOf(x) != -1){
      Console.WriteLine($"{task[i].ProcessName, -40} {task[i].Id}");}
  }}


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

static bool IsDigitsOnly(string str)
{
    foreach (char c in str)
    {
        if (c < '0' || c > '9')
            return false;
    }
    return true;
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
      if (command.Split().Length > 1 && IsDigitsOnly(command.Split()[1])){
      KillById(Convert.ToInt32(command.Split()[1]), tasks);}
    }
    else if (command.StartsWith("killbyname")){
      if (command.Split().Length > 1){
        KillByName(command.Split(" ")[1], tasks);}
    }
    else if (command.StartsWith("search")){
      if (command.Split().Length > 1){
        Search(command.Split(" ")[1], tasks);}
    }
    else if (command.StartsWith("exit")){
      break;}
    else {
       Console.WriteLine("ERROR");
    }
    }
  }
}
