   unsafe class Program
    {
            //www.kernsteinist.blogspot.com.tr
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr FindResource(int hModule, string lpName, string lpType);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern int SizeofResource(int hModule, IntPtr hResInfo);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr LoadResource(int hModule, IntPtr hResInfo);


            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr LockResource(IntPtr hResData);



   
        static void Main(string[] args)
        {           

           IntPtr HRSRC = FindResource(0, "Kern", "RT_RCDATA");
           int size = SizeofResource(0, HRSRC);
           IntPtr hResData = LoadResource(0, HRSRC);
           IntPtr s = LockResource(hResData);

            byte* b = (byte*)(s); 
          

            Console.WriteLine("......");
            for (int i = 0; i < size; i++)
            {
                byte data1 = (byte)*(b+i);              
                Console.Write(data1.ToString()+" ");
              
            }

            Console.WriteLine("......");

            for (int i = 0; i < size; i++)
            {
                byte data1 = (byte)*(b + i);        
                Console.Write((char)data1);
             }
        }       
    }
