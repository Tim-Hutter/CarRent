// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Authorization;
using FastEndpoints;
using CarRent.Feature.Cars.Domain;
using CarRent.Feature.Cars.Infrastructure;
using CarRent.Persistence;
using CarRent.Common.Domain;

namespace CarRent.Feature.Cars.Api
{
    public class CreateCarEndpoint : Endpoint<CarRequest, CarResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarRepository _repository;

        public CreateCarEndpoint(IUnitOfWork unitOfWork, ICarRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public override void Configure()
        {
            Post("/cars");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CarRequest req, CancellationToken ct)
        {
            var car = new Car
            {
                Name = req.Name
            };

            _repository.Add(car);

            _unitOfWork.CommitChanges();

            await SendCreatedAtAsync<GetCarByIdEndpoint>(null, new CarResponse
            {
                Id = car.Id,
                Name = car.Name
            });
        }
    }
}
