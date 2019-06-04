namespace linq
{
    class ReportItem{
        public string CustomerName { get; set; }
            public string BankName { get; set; }

            public string GetLastName()
        {
            return this.CustomerName.Split(" ")[1];
        }
    }
    
}