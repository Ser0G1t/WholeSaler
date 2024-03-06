namespace WholeSaler.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message): base(message) 
        { 
        }
    }
}
