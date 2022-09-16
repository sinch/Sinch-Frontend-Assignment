namespace Sinch.Config.Mgmt.Errors;

public class DocumentNotFoundException : Exception
{
    public DocumentNotFoundException(string? message) : base(message){}
}
