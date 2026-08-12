using System;
using System.Reflection;

namespace NetInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("         THONG TIN MOI TRUONG THUC THI (.NET)");
       
            Console.WriteLine("--- Thông tin CLR / .NET ---");
            Console.WriteLine($"Phiên bản CLR (Environment.Version): {Environment.Version}");

            // Sử dụng System.Reflection 
            string frameworkDescription = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            Console.WriteLine($"Mô tả Runtime (RuntimeInformation): {frameworkDescription}");

            // Lấy tên và phiên bản của Assembly đang thực thi bằng Reflection
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = currentAssembly.GetName();
            Console.WriteLine($"Tên Assembly đang chạy: {assemblyName.Name}");
            Console.WriteLine($"Phiên bản Assembly: {assemblyName.Version}");
            Console.WriteLine($"Vị trí Assembly: {currentAssembly.Location}\n");

            //  2. THÔNG TIN MÁY TÍNH & NGƯỜI DÙNG 
            Console.WriteLine("--- Thông tin máy tính & người dùng ---");
            Console.WriteLine($"Tên máy tính (MachineName): {Environment.MachineName}");
            Console.WriteLine($"Tên người dùng đăng nhập (UserName): {Environment.UserName}");
            Console.WriteLine($"Tên miền người dùng (UserDomainName): {Environment.UserDomainName}\n");

            //  3. HỆ ĐIỀU HÀNH & KIẾN TRÚC CPU 
            Console.WriteLine("--- Hệ điều hành & Kiến trúc CPU ---");
            Console.WriteLine($"Hệ điều hành (OSVersion): {Environment.OSVersion}");
            Console.WriteLine($"Số nhân xử lý (ProcessorCount): {Environment.ProcessorCount}");

            // Kiểm tra kiến trúc 64-bit hay 32-bit
            string osArch = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
            string processArch = Environment.Is64BitProcess ? "64-bit" : "32-bit";
            Console.WriteLine($"Kiến trúc hệ điều hành: {osArch}");
            Console.WriteLine($"Kiến trúc tiến trình đang chạy: {processArch}\n");

            //  4. THÔNG TIN GARBAGE COLLECTOR (GC) 
            Console.WriteLine("--- Thông tin Garbage Collector (GC) ---");


            long totalMemoryBytes = GC.GetTotalMemory(false);
            double totalMemoryMB = totalMemoryBytes / 1024.0 / 1024.0;

            Console.WriteLine($"Bộ nhớ đang được GC quản lý: {totalMemoryBytes:N0} bytes (~{totalMemoryMB:F2} MB)");

            // Số thế hệ (generation) tối đa mà GC hỗ trợ trên máy hiện tại
            Console.WriteLine($"Số thế hệ GC tối đa (MaxGeneration): {GC.MaxGeneration}");

            // Số lần thu gom rác đã xảy ra ở từng thế hệ (0, 1, 2)
            for (int gen = 0; gen <= GC.MaxGeneration; gen++)
            {
                Console.WriteLine($"Số lần GC đã thu gom ở Gen {gen}: {GC.CollectionCount(gen)}");
            }

            Console.WriteLine("\n============================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
