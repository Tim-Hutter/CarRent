// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;
using CarRent.Feature.Cars.Domain;
using CarRent.Feature.Cars.Infrastructure;
using FastEndpoints;

namespace CarRent.Feature.Cars.Api
{
    public class GetCarsEndpoint : EndpointWithoutRequest<IEnumerable<CarResponse>>
    {
        private readonly ICarRepository _repository;

        public GetCarsEndpoint(ICarRepository repository)
        {
            _repository = repository;
        }
        public override void Configure()
        {
            Get("/cars");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var cars = _repository.GetCars();
            var response = cars.Select(car => new CarResponse
            {
                Id = car.Id,
                Name = car.Name
            });
            await SendOkAsync(response, ct);
        }
    }
}
