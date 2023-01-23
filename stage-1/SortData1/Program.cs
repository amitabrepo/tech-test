namespace SortData
{
    public class FilterData
    {
        
        public static void Main(string[] args)
        {
            FindCustomerData data = new()
            {
                InputData = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"InputData\Data.txt",
                OutputData = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"InputData\OutputData.txt"
            };
            data.GetCustomerDetails();
        }
    }
}