using System;
using System.Reflection;

namespace NetInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("      THONG TIN MOI TRUONG THUC THI (.NET)");
            Console.WriteLine("============================================\n");

            // ================= 1. THONG TIN VE CLR / .NET =================
            Console.WriteLine("--- Thong tin CLR / .NET ---");
            Console.WriteLine($"Phien ban CLR (Environment.Version): {Environment.Version}");

            // Su dung System.Reflection de lay thong tin mo ta framework/runtime cu the hon
            string frameworkDescription = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            Console.WriteLine($"Mo ta Runtime (RuntimeInformation): {frameworkDescription}");

            // Lay ten va phien ban cua Assembly dang thuc thi bang Reflection
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = currentAssembly.GetName();
            Console.WriteLine($"Ten Assembly dang chay: {assemblyName.Name}");
            Console.WriteLine($"Phien ban Assembly: {assemblyName.Version}");
            Console.WriteLine($"Vi tri Assembly: {currentAssembly.Location}\n");

            // ================= 2. THONG TIN MAY TINH & NGUOI DUNG =================
            Console.WriteLine("--- Thong tin may tinh & nguoi dung ---");
            Console.WriteLine($"Ten may tinh (MachineName): {Environment.MachineName}");
            Console.WriteLine($"Ten nguoi dung dang nhap (UserName): {Environment.UserName}");
            Console.WriteLine($"Ten mien nguoi dung (UserDomainName): {Environment.UserDomainName}\n");

            // ================= 3. HE DIEU HANH & KIEN TRUC CPU =================
            Console.WriteLine("--- He dieu hanh & Kien truc CPU ---");
            Console.WriteLine($"He dieu hanh (OSVersion): {Environment.OSVersion}");
            Console.WriteLine($"So nhan xu ly (ProcessorCount): {Environment.ProcessorCount}");

            // Kiem tra kien truc 64-bit hay 32-bit
            string osArch = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
            string processArch = Environment.Is64BitProcess ? "64-bit" : "32-bit";
            Console.WriteLine($"Kien truc he dieu hanh: {osArch}");
            Console.WriteLine($"Kien truc tien trinh dang chay: {processArch}\n");

            // ================= 4. THONG TIN GARBAGE COLLECTOR (GC) =================
            Console.WriteLine("--- Thong tin Garbage Collector (GC) ---");

            // GC.GetTotalMemory(false) tra ve so byte bo nho dang duoc quan ly boi GC
            long totalMemoryBytes = GC.GetTotalMemory(false);
            double totalMemoryMB = totalMemoryBytes / 1024.0 / 1024.0;

            Console.WriteLine($"Bo nho dang duoc GC quan ly: {totalMemoryBytes:N0} bytes (~{totalMemoryMB:F2} MB)");

            // So the he (generation) toi da ma GC ho tro tren may hien tai
            Console.WriteLine($"So the he GC toi da (MaxGeneration): {GC.MaxGeneration}");

            // So lan GC da thu gom o tung the he (0, 1, 2)
            for (int gen = 0; gen <= GC.MaxGeneration; gen++)
            {
                Console.WriteLine($"So lan GC da thu gom o Gen {gen}: {GC.CollectionCount(gen)}");
            }

            Console.WriteLine("\n============================================");
            Console.WriteLine("Nhan phim bat ky de thoat...");
            Console.ReadKey();
        }
    }
}
