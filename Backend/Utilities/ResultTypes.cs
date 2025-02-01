namespace SNS.Utilities
{
    public class ResultTypes<T1,T2>
    {
        public T1? Descri { get; }
        public T2? Count { get; }
        public string? Message { get; }
        public bool IsSuccess { get; }

        private ResultTypes(T1 dataType, T2 data)
        {
            Descri = dataType;
            Count = data;
            Message = null;
            IsSuccess = true;
        }

        private ResultTypes(string message)
        {
            Descri = default;
            Count = default;
            Message = message;
            IsSuccess = false;
        }

        public static ResultTypes<T1,T2> IsValid(T1 dataType, T2 data)
        {
            return new ResultTypes<T1, T2>(dataType,data);
        }

        public static ResultTypes<T1, T2> NotValid()
        {
            string message = $"O recurso procurado não foi encontrado.";
            return new ResultTypes<T1, T2>(message);
        }
    }
}
