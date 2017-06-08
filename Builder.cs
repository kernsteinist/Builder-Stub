
    class Program
    {
        //www.kernsteinist.blogspot.com.tr
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr BeginUpdateResource(string pFileName,bool bDeleteExistingResources);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UpdateResource(IntPtr hUpdate, string lpType, string lpName, ushort wLanguage, byte[] lpData, uint cbData);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

       static byte[] Convert_To_Byte(string to_be_added)
        {
            byte[] to_byte = new byte[to_be_added.Length];

            for (int i = 0; i < to_be_added.Length; i++)
            {
                char c = to_be_added[i];
                to_byte[i] = (byte)c;

            }

            return to_byte;
        }


        static void Main(string[] args)
        {


            Console.WriteLine("Enter  value :");
            string to_be_added = Console.ReadLine();

            File.Copy("STUB.EXE", "Kernsteinist.EXE",true);
            

            IntPtr hUpdate = BeginUpdateResource("Kernsteinist.exe", false);
            bool error = UpdateResource(hUpdate,"RT_RCDATA", "Kern", 0, Convert_To_Byte(to_be_added),(uint)to_be_added.Length);
            if (!error)
            {
                Console.WriteLine("Error...");
                Console.WriteLine(Marshal.GetLastWin32Error());
                EndUpdateResource(hUpdate, true);
            }
            else
            {
                EndUpdateResource(hUpdate, false);
                Console.WriteLine("Succesful...");
                
            } 
         }
    }
