class Program
{
    static StreamReader sr = new StreamReader("input.txt");
    static MyArrayList<string> Teg()
    {
        bool isOpen = false;
        bool isClose = false;
        string? line = sr.ReadLine();
        if (line == null) throw new Exception("Пустой файл");
        var arrayTeg = new MyArrayList<string>(15);
        string teg = "";
        while(line != null)
        {
            isOpen = false; teg = "";
            for(int i = 0; i < line.Length; i++)
            {
                if(line[i] == '<' && line[i + 1] != null)
                {
                    if((line[i + 1] == '/' || char.IsLetter(line[i + 1])) && !isOpen) { isOpen = true; }
                    else 
                    {
                        i++;
                        while(i < line.Length)
                        {
                            if(line[i] == '<') break;
                            i++;
                        }
                        teg = "";
                    }
                    if (i == line.Length) break;
                }
                if (line[i] == '>' && isOpen) {isOpen = false; teg += line[i]; isClose = true;}
                if (isOpen && (line[i] == '<' || line[i] == '>' || line[i] == '/' || char.IsLetter(line[i]))) {teg += line[i];}
                if(isClose) {arrayTeg.Add(teg); teg = ""; isClose = false;}
            }
            line = sr.ReadLine();
        }
        sr.Close();
        return arrayTeg;
    }

    static MyArrayList<string> RemoveDublicates (MyArrayList<string> arrayTeg)
    {
        MyArrayList<string> lowerCaseTeg = new MyArrayList<string>(15);

        for(int i = 0; i < arrayTeg.Size(); i++){ lowerCaseTeg.Add(i, arrayTeg.Element(i).ToLower());}
        
        int countDublicate = 0;
        for(int i = 0; i < lowerCaseTeg.Size(); i++)
        {
            for(int j = i + 1; j < lowerCaseTeg.Size(); j++)
            {
                if(lowerCaseTeg.Element(i) == lowerCaseTeg.Element(j))
                {
                    lowerCaseTeg.Remove(lowerCaseTeg.Element(j));
                    lowerCaseTeg.Add(j, "false");
                    countDublicate++;
                }
            }
        }
        MyArrayList <string> result = new MyArrayList<string>(15);
        for(int i = 0; i < lowerCaseTeg.Size(); i++)
        {
            if(lowerCaseTeg.Element(i) == "false") continue;
            result.Add(arrayTeg.Element(i));
        }
        return result;
    }
    
    private static void Main(string[] args)
    {
        MyArrayList<string> arr = Teg();
        Console.WriteLine("Данные, полученные из файла: ");
        arr.Print();
        Console.WriteLine();
        Console.WriteLine("Данные, полученные из файла, после удаления повторяющихся элементов: ");
        MyArrayList<string> newArray = RemoveDublicates(arr);
        newArray.Print();
    }
}


