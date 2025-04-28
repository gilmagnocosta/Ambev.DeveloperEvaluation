using Ambev.DeveloperEvaluation.Domain.ValueObjects.Base;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Name : ValueObject
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public Name() { }

    public Name(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }

    public void SetName(string firstname, string lastname)
    {
        Firstname = firstname;
        Lastname = lastname;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Firstname;
        yield return Lastname;
    }
}
