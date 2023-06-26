
List<string> TaskList = new List<string>();


int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);

/// <summary>
/// Show the options for task
/// </summary>
/// <returns>Returns option indicated by user</returns>
/// 

void ShowListTaks()
{
    int IndexTask = 0;
    Console.WriteLine("----------------------------------------");
    TaskList.ForEach(p => Console.WriteLine($"{++IndexTask} . {p}"));
    Console.WriteLine("----------------------------------------");
}

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string lineForMenu = Console.ReadLine();

    if (Convert.ToInt32(lineForMenu) > 0 && Convert.ToInt32(lineForMenu) <=4)
    {
        return Convert.ToInt32(lineForMenu);
    }
    else
    {
        Console.WriteLine("Digita un valor correcto.. ");
        return 0;
    }
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowListTaks();

        string lineRemove = Console.ReadLine();
        // Remove one position because the array satrt position 
        int indexToRemove = Convert.ToInt32(lineRemove) - 1;

        if (indexToRemove > (TaskList.Count - 1) && indexToRemove < 0)
        {
            Console.WriteLine("Valor ingresado no valido");
        }
        else
        {
            if (indexToRemove > -1 || TaskList.Count > 0)
            {
                string taskToRemove = TaskList[indexToRemove];
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskToRegister = Console.ReadLine();
        if (!taskToRegister.Equals(""))
        {
            TaskList.Add(taskToRegister);
            Console.WriteLine("Tarea registrada");
        }
        else
        {
            Console.WriteLine("Tarea vacia, verifica tu tarea.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        ShowListTaks();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}


