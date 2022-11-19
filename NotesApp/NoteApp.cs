namespace NotesApp
{
    public class NoteApp
    {
        string command;

        // Application
        public void Run()
        {
            string NoteDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Notes\";

            Directory.CreateDirectory(NoteDirectory);

            // Application Loop
            while (command != "exit")
            {
                Console.WriteLine("(new) new Note");
                Console.WriteLine("(show) show Notes");
                Console.WriteLine("(open) open Note");
                Console.WriteLine("(delete) delete Note");
                Console.WriteLine("(exit) exit App");
                Console.WriteLine("(clear) clear Console");
                string command = Console.ReadLine();
                
                if(command == "new")
                {
                    Console.WriteLine("\n");
                    MakeNote();
                }

                if(command == "show")
                {
                    Console.WriteLine("\n");
                    ShowNotes();
                }

                if(command == "open")
                {
                    Console.WriteLine("\n");
                    OpenNote();
                }

                if(command == "delete")
                {
                    Console.WriteLine("\n");
                    DeleteNote();
                }

                if(command == "exit")
                {
                    Environment.Exit(0);
                }

                if(command == "clear")
                {
                    Console.Clear();
                }
                
                else
                {
                    continue;
                }

                // Creates a .txt file and adds whatever the user typed in to it
                void MakeNote()
                {
                    Console.WriteLine("Title of the Note");
                    string title = Console.ReadLine() + ".txt";

                    Console.Write("Type in Note: ");
                    string input = Console.ReadLine();

                    try
                    {
                        using(var streamWriter = File.CreateText(NoteDirectory + title))
                        {
                            streamWriter.WriteLine(input);
                            streamWriter.Dispose();
                            streamWriter.Close();
                        }
                        Console.WriteLine($"Note: {input} has been created!");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return;
                }
                
                // Shows all files which the user has created
                void ShowNotes()
                {
                    try
                    {
                        var files = Directory.GetFiles(NoteDirectory, "*", SearchOption.AllDirectories);

                        Console.WriteLine("\n");
                        foreach (var file in files)
                        {
                            
                            Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

                // Shows the content inside a .txt file
                void OpenNote()
                {
                    Console.WriteLine("Which Note do you want to open? ");
                    Console.Write("Note: ");
                    string input = Console.ReadLine() + ".txt";

                    List<string> text = new List<string>(File.ReadAllLines(NoteDirectory + input).ToList());

                    foreach (var line in text)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("Text: ");
                        Console.WriteLine(line);
                        Console.WriteLine("\n");
                    }
                }

                //Removes a .txt file
                void DeleteNote()
                {
                    Console.WriteLine("Which Note do you want to be deleted? ");
                    Console.Write("Note: ");
                    string input = Console.ReadLine() + ".txt";

                    File.Delete(NoteDirectory + input);
                    
                    Console.WriteLine($"File: {input} has been deleted");
                }
            }
        }
    }
}