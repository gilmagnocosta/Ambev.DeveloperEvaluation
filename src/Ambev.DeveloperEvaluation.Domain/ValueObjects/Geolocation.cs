using Ambev.DeveloperEvaluation.Domain.ValueObjects.Base;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Geolocation : ValueObject
{
    public string Lat { get; set; }
    public string Long { get; set; }

    public void SetLocation(string lat, string lng)
    {
        Lat = lat;
        Long = lng;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Lat;
        yield return Long;
    }
}
