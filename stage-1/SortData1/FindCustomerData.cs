using System.Text;

namespace SortData
{
    internal class FindCustomerData
    {
        private IEnumerable<string>? _allLines;
        private StringBuilder? _studentInfoHolder;
        private string? _inputFilePath;
        private string? _outputFilePath;
        private List<string>? _stringList;

        public string? InputData { get => _inputFilePath; set => _outputFilePath = value; }
        public string? OutputData { get => _outputFilePath; set => _outputFilePath = value; }

        public FindCustomerData()
        {
            InputData = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"InputData\Data.txt";
            OutputData = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"InputData\OutputData.txt";
        }
        public void GetCustomerDetails()
        {
            _inputFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"InputData\Data.txt";
            _allLines = File.ReadLines(_inputFilePath);

            _outputFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"OutputData\OutputData.txt";
            var exists = File.Exists(_outputFilePath);
            var fileMode = exists
                ? FileMode.Truncate   
                : FileMode.CreateNew;

            //filter and output data file operation
            _studentInfoHolder = new StringBuilder();
            _studentInfoHolder.AppendFormat("Customer Data\r\n************************************************\r\n");
            foreach (var line in _allLines.Skip<string>(1))
            {
                _stringList = line.Split(',').ToList();
                if (_stringList.Count is 0)
                {
                    _studentInfoHolder.AppendFormat("No discrepancy found\r\n");
                    break;
                }
                if (int.Parse(_stringList[1]) is >= 40 and <= 59)
                {
                    _studentInfoHolder.AppendFormat($"Customer Name: {_stringList[0]}\r\nPhone: {_stringList[_stringList.Count - 2]}" +
                        $"\r\nEmail: {_stringList[_stringList.Count - 1]}\r\n");
                    _studentInfoHolder.AppendFormat("************************************************\r\n");
                }

            }
            File.WriteAllText(_outputFilePath, _studentInfoHolder.ToString());
        }

    }
}
