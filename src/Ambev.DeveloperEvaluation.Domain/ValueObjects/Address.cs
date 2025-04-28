using Ambev.DeveloperEvaluation.Domain.ValueObjects.Base;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Address : ValueObject
{
    public string City { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string ZipCode { get; set; }
    public Geolocation Geolocation { get; set; }

    public Address() { }

    public Address(string city, string street, string number, string zipCode, Geolocation geolocation)
    {
        City = city;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        Geolocation = geolocation;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return Number;
        yield return ZipCode;
        yield return Geolocation;
    }
}
