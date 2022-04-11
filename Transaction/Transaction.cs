namespace Bank
{
    internal abstract class Transaction
    {
        protected string Message{ get; private set; }
        public string Status{ get; protected set; }

        public string Result { get; protected set; }

        protected Transaction(string message)
        {
            Message = message;
            Status = "Not executed";
            Result = "Not executed";
        }
    }
}
