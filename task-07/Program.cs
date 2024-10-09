internal class Program
{
    static StreamReader sr = new StreamReader("input.txt");
    static StreamWriter sw = new StreamWriter("output.txt");

    static MyVector<string> IpAdress()
    {
        string? line = sr.ReadLine();
        if (line == null) throw new Exception("Пустой файл");
        MyVector<string> vector = new MyVector<string>(15);
        while(line != null)
        {
            string[] arrayOfIpAddress = line.Split(' ');
            foreach(string adress in arrayOfIpAddress)
            {
                bool isIpAdress = true;
                int[]blockIp = adress.Split(".").Select(x => Convert.ToInt32(x)).ToArray();
                foreach(int elem in blockIp)
                {
                    if(elem > 255 || elem < 0) {isIpAdress = false;}
                }
                if(isIpAdress && blockIp.Length == 4) {vector.Add(adress);}
            }
            line = sr.ReadLine();
        }
        sr.Close();
        return vector;
    }
        
    static void WriteIpToFile(MyVector<string> ipAdress)
    {
        for(int i = 0; i < ipAdress.Size(); i++)
        {
            string ip = ipAdress.Get(i);
            sw.WriteLine(ip);
        }
        sw.Close();
    }

    private static void Main(string[] args)
    {
        MyVector<string> vector = new MyVector<string>(15);
        vector = IpAdress();
        WriteIpToFile(vector);
    }
}