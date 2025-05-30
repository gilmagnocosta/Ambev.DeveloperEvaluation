﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.Shared.Models
{
    public class AddressModel
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public GeolocationModel Geolocation { get; set; }
    }
}
