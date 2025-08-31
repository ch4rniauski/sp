using System.Text;

namespace laba1
{
    public partial class Form1 : Form
    {
        private int _passwordLengh = 8;
        private const int _passHistoryLength = 5;
        private const string _fileToSaveHistoryName = "history.txt";
        private bool _includeNumbers = false;
        private readonly List<string> _passHistory = new(_passHistoryLength);

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _includeNumbers = _includeNumbers switch
            {
                true => false,
                _ => true
            };
        }

        private string GeneratePassWithoutNums()
        {
            var rnd = new Random();
            var strBuilder = new StringBuilder(_passwordLengh);

            for (int i = 0; i < _passwordLengh; i++)
            {
                GenerateChar(rnd, strBuilder);
            }

            return strBuilder.ToString();
        }

        private string GeneratePassWithNums()
        {
            var rnd = new Random();
            var strBuilder = new StringBuilder(_passwordLengh);

            for (int i = 0; i < _passwordLengh; i++)
            {
                var isNumber = rnd.Next(2) == 0;

                if (isNumber)
                {
                    strBuilder.Append(rnd.Next(10));
                }
                else
                {
                    GenerateChar(rnd, strBuilder);
                }
            }

            return strBuilder.ToString();
        }

        private void GenerateChar(Random rnd, StringBuilder strBuilder)
        {
            var isUpper = rnd.Next(2) == 0;

            strBuilder.Append((char)(isUpper
                ? rnd.Next('A', 'Z' + 1)
                : rnd.Next('a', 'z' + 1)));
        }

        private void generatePassButton_Click(object sender, EventArgs e)
        {
            var pass = _includeNumbers
                ? GeneratePassWithNums()
                : GeneratePassWithoutNums();

            passLabel.Text = $"Пароль: {pass}";

            PassHistoryManipulation(pass);
            SaveHistoryIntoFile();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            passLengthLabel.Text = "8";
            _passwordLengh = 8;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            passLengthLabel.Text = "12";
            _passwordLengh = 12;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            passLengthLabel.Text = "16";
            _passwordLengh = 16;
        }

        private void PassHistoryManipulation(string pass)
        {
            if (_passHistory.Count < _passHistoryLength)
            {
                _passHistory.Insert(0, pass);
            }
            else
            {
                _passHistory.RemoveAt(_passHistoryLength - 1);
                _passHistory.Insert(0, pass);
            }

            passHistoryListBox.Items.Clear();

            foreach (var password in _passHistory)
            {
                passHistoryListBox.Items.Add(password);
            }
        }

        private void SaveHistoryIntoFile()
        {
            try
            {
                File.WriteAllLines(_fileToSaveHistoryName, _passHistory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void loadHistoryFromFileButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_fileToSaveHistoryName))
            {
                MessageBox.Show("Файл истории паролей не найден.");
                return;
            }

            _passHistory.Clear();

            var lines = File.ReadAllLines(_fileToSaveHistoryName)
                .Take(3)
                .ToList();

            foreach (var line in lines)
            {
                _passHistory.Insert(0, line);
            }

            passHistoryListBox.Items.Clear();

            foreach (var pass in _passHistory)
            {
                passHistoryListBox.Items.Add(pass);
            }
        }
    }
}
